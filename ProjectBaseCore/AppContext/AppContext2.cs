using Microsoft.Extensions.Configuration;
using ProjectBaseCore.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBaseCore.AppContext
{
    /// <summary>
    /// Includes parameters that are assotiated with current application.
    /// </summary>
    public static class AppContext2
    {
        public static IConfiguration AppSettings
        {
            get
            {
                return ConfigurationManager.AppSetting;
            }
        }
        public static bool InDevelopment
        {
            get
            {
                return ConfigurationManager.IsDevelopment();
            }
        }
        public static string DEFAULT_DB
        {
            get
            {
                if (ConfigurationManager.GetSection("DefaultDb") != null)
                {
                    return ConfigurationManager.GetSection("DefaultDb");
                }
                else
                    return "Context";
            }
        }
        /// <summary>
        /// Connection string that is stored in config file.
        /// </summary>
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.GetConnectionString(name);
        }
        /// <summary>
        /// Returns a parameter's value that is stored in config file.
        /// </summary>
        public static string GetParameterValue(string name)
        {
            return ConfigurationManager.GetSection(name);
        }
    }
}
