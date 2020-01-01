using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public static class ConfigurationManager
    {
        // You Will have to change the following path
        private static  readonly string _path = @"C:\Users\danir\source\repos\FileManager\FileManager\";
        private static IConfigurationRoot configuration;

        static ConfigurationManager()
        {
            var _ = new ConfigurationBuilder()
                            .SetBasePath(_path)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = _.Build();
        }

        public static int GetValue()
        {
            return int.Parse(configuration.GetSection("MalwareSize").Value);
        }
    }
}
