using System;

namespace deepin_ext_cal_sync.Helpers
{
    public class DeepinCalHelper
    {
        /// <summary>
        /// Deepin Calendar seems to work only if the time string contains the +16 as timezone
        /// and month and min always be 2 digits long, implementing  a dirty fix for now
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDeepinCalDateTime(DateTime d)
        {
            return $"{d.Year}-{EnsureTwoDigits(d.Month)}-{EnsureTwoDigits(d.Day)}T{EnsureTwoDigits(d.Hour)}:{EnsureTwoDigits(d.Minute)}:00+16:00";
        }

        static string EnsureTwoDigits(int num)
        {
            return $"{(num <= 9 ? "0" : "")}{num}";
        }

    }
}