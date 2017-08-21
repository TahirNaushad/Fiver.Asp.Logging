using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Fiver.Asp.Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddFilter((category, level) =>
                                category.Contains("Fiver.Asp.Logging.HelloLoggingMiddleware"));
                })
                .UseStartup<Startup>()
                .Build();

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .ConfigureLogging((context, builder) =>
        //        {
        //            builder.AddConsole();
        //            builder.AddDebug();
        //        })
        //        .UseStartup<Startup>()
        //        .Build();
    }
}
