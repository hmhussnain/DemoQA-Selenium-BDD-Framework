using Microsoft.Extensions.Configuration;
using System.IO;

namespace DemoQA.Automation.Utilities
{
    public static class ConfigReader
    {
        private static IConfigurationRoot _config;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _config = builder.Build();
        }

        public static string GetBrowser() => _config["Browser"]!;
        public static string GetBaseUrl() => _config["BaseUrl"]!;
    }
}
