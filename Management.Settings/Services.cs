using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Settings
{
    public class Services
    {
        public static ConcurrentDictionary<string, string> dict = new ConcurrentDictionary<string, string>(); 
        public Services(ConcurrentDictionary<string, string> appSetting)
        {
            dict = appSetting;
        }
        public static string ConnectionStringAppDb()
        {
            string conn = GetPlural("ConnectionStringCoreDb");
            if (string.IsNullOrEmpty(conn))
            {
                conn = "Server=DESKTOP-KT5MIVF;Database=CoreDb;Trusted_Connection=True;";
            }
            return conn;
        }
        public static string GetPlural(string word)
        {
            string result;
            if (dict.TryGetValue(word, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

    }
}
