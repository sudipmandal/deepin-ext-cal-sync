using System;
using System.IO;
using System.Reflection;

namespace deepin_ext_cal_sync.Helpers
{
    public class Utils
    {
        public static string GetExeFolder()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}