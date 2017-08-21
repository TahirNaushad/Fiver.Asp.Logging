using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Fiver.Asp.Logging
{
    public static class UseMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloLoggingMiddleware>();
        }
    }

    public class HelloLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<HelloLoggingMiddleware> logger;

        public HelloLoggingMiddleware(
            RequestDelegate next,
            ILogger<HelloLoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            this.logger.LogInformation(101, "Inoke executing");
            await context.Response.WriteAsync("Hello Logging!");
            this.logger.LogInformation(201, "Inoke executed");
        }
    }

    //public class HelloLoggingMiddleware
    //{
    //    private readonly RequestDelegate next;
    //    private readonly ILogger logger;

    //    public HelloLoggingMiddleware(
    //        RequestDelegate next,
    //        ILoggerFactory loggerFactory)
    //    {
    //        this.next = next;
    //        this.logger = loggerFactory.CreateLogger("Hello_Logging_Middleware");
    //    }

    //    public async Task Invoke(HttpContext context)
    //    {
    //        this.logger.LogInformation(101, "Inoke executing");
    //        await context.Response.WriteAsync("Hello Logging!");
    //        this.logger.LogInformation(201, "Inoke executed");
    //    }
    //}
}
