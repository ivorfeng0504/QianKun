using System.IO;
using Microsoft.Extensions.Configuration;

namespace QianKunHelper
{
    public class ConfigurationManager
    {
        private static IConfiguration configuration;
        private static readonly object obj = new object();

        public static IConfiguration AppSettings
        {
            get
            {
                if (configuration != null) return configuration;
                lock (obj)
                {
                    if (configuration != null) return configuration;
                    configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
                    return configuration;
                }
            }
        }

    }
}
