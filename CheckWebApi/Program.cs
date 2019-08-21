using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using QianKunHelper;

namespace CheckWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseUrls(ConfigurationManager.AppSettings["UseUrls"] ?? "http://*:9966")
                .UseStartup<Startup>();
    }
}
