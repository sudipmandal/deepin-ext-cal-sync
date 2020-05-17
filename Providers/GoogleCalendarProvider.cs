using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using deepin_ext_cal_sync.Models;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.IO;

namespace deepin_ext_cal_sync.Providers
{
    public class GoogleCalendarProvider : Models.ICalProvider
    {
        string[] Scopes = { CalendarService.Scope.CalendarReadonly };

        string ApplicationName;
        string ClientId;
        string Secret;
        string CalendarId;
        int daysToSyncBefore = 0;
        int daysToSyncAfter = 0;

        public GoogleCalendarProvider()
        {
            Console.WriteLine(Helpers.Utils.GetExeFolder());
            string configStr = File.ReadAllText(Helpers.Utils.GetExeFolder() + "/config.json");
            JObject config = JObject.Parse(configStr);

            this.daysToSyncBefore = int.Parse(config["DaysToSyncBeforeToday"].ToString()) * -1;
            this.daysToSyncAfter = int.Parse(config["DaysToSyncAfterToday"].ToString());

            config = JObject.FromObject(config["Providers"]["Google"]);

            this.ApplicationName = config["ApplicationName"].ToString();
            this.ClientId = config["ClientId"].ToString();
            this.Secret = config["ClientSecret"].ToString();
            this.CalendarId = config["CalendarId"].ToString();


        }

        public List<DeepinCalEvent> GetEvents(DateTime startDt, DateTime endDt)
        {
            UserCredential credential;
            string credPath = Helpers.Utils.GetExeFolder() + "/token.json";

            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = this.ClientId,
                    ClientSecret = this.Secret
                },
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List(this.CalendarId);
            request.TimeMin = DateTime.Now.AddDays(this.daysToSyncBefore);
            request.TimeMax = DateTime.Now.AddDays(this.daysToSyncAfter);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 1000;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();

            List<DeepinCalEvent> result = new List<DeepinCalEvent>();
            foreach (var item in events.Items)
            {
                var newEntry = new Models.DeepinCalEvent()
                {
                    Title = item.Summary,
                    Start = Helpers.DeepinCalHelper.ToDeepinCalDateTime(item.Start.DateTime.Value),
                    End = Helpers.DeepinCalHelper.ToDeepinCalDateTime(item.End.DateTime.Value),
                    AllDay = false
                };
                result.Add(newEntry);
            }

            return result;


        }
    }
}