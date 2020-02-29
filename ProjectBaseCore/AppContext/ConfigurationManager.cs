using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBaseCore.AppContext
{
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static ConfigurationManager()
        {
            AppSetting = GetConfig();
        }
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public static bool IsDevelopment()
        {
            return (AppSetting["Environment"] != null && AppSetting["Environment"] == "Development") ? true : false;
        }
        public static string GetSection(string section)
        {
            return AppSetting[section];
        }
        public static string GetConnectionString(string section)
        {
            return AppSetting.GetConnectionString(section);
        }
    }
}
