using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TandVark_ASP.NETCORE_REACT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //private static ConfigurationLogger(WebHostBuilder hostingContext, ILoggingBuilder logging)
        //{
        //    var logger = 
        //}
    }
}
