using System;
using Calendar.DBus;
using Tmds.DBus;
using System.Threading.Tasks;
using Newtonsoft;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace deepin_ext_cal_sync
{
    class Program
    {
        static Connection sessionConnection;
        static IScheduler calendarScheduler;



        static async Task Main(string[] args)
        {
            sessionConnection = Connection.Session;
            calendarScheduler = sessionConnection.CreateProxy<IScheduler>
                                        ("com.deepin.daemon.Calendar", "/com/deepin/daemon/Calendar/Scheduler");

            // Read settings.json
            DateTime queryStart = DateTime.Now.Date.AddDays(-5);
            DateTime queryEnd = DateTime.Now.Date.AddDays(15);

            // : Connect to External Calendar and get entries for specified days
            //TO DO : Make calendar provider configurable
            Models.ICalProvider extCal = new Providers.GoogleCalendarProvider();
            var newEntries = extCal.GetEvents(queryStart, queryEnd);

            // Retrieve all entries from Deepin Calendar for specified days
            var oldEntries = await GetAllDeepinCalendarEntries(queryStart, queryEnd);

            //Delete all retreived entries from Deepin Calendar
            await RemoveAllDeepinCalendarEntries(oldEntries);

            //Insert all External Calendar entries into Deepin Calendar
            await InsertEntriesToDeepinCalendar(newEntries);

        }

        static async Task<JArray> GetAllDeepinCalendarEntries(DateTime queryStart, DateTime queryEnd)
        {
            var rawResult = await calendarScheduler.GetJobsAsync(
                queryStart.Year,
                queryStart.Month,
                queryStart.Day,
                queryEnd.Year,
                queryEnd.Month,
                queryEnd.Day
                );

            return JArray.Parse(rawResult);
        }

        static async Task RemoveAllDeepinCalendarEntries(JArray jobsResult)
        {
            //Delete all calendar entries for the selected query duration.
            var oldEntries = jobsResult.Where(x => x["Jobs"].Count() > 0).ToList();
            foreach (var j in oldEntries)
            {
                var jobs = JArray.FromObject(j["Jobs"]);
                foreach (var job in jobs)
                {
                    await calendarScheduler.DeleteJobAsync(long.Parse(job["ID"].ToString()));
                }
            }

        }

        static async Task InsertEntriesToDeepinCalendar(List<Models.DeepinCalEvent> entries)
        {
            Console.WriteLine("Inserting " + entries.Count);
            foreach (var item in entries)
            {
                await calendarScheduler.CreateJobAsync(JsonConvert.SerializeObject(item));
            }
        }
    }
}
