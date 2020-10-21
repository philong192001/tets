using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nam.ULTILS.ReadConfig
{
    public static class GetConfig
    {
        public static IConfiguration Configuration { get; set; }
        public static string ReadConfig(string key, string value, string defaultValue)
        {
            string result  = Configuration[""+ key + ":"+ value + ""];
            if(result == null)
            {
                return defaultValue;
            }
            else
            {
                return result;
            }
        }
    }
}
