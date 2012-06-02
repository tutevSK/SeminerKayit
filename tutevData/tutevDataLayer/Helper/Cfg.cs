using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace tutevData.Helper
{
    public class Cfg
    {

        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
            
            //ConfigurationSettings.AppSettings[key];
        }

    }
}
