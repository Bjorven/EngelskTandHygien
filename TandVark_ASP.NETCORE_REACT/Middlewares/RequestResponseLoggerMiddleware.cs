using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace TandVark_ASP.NETCORE_REACT.Middlewares
{
    public class RequestResponseLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            Console.WriteLine("=============================");
            Console.WriteLine("========Request=========");

            var request = context.Request;
            System.Console.WriteLine($"Path: {request.Path}");
            Console.WriteLine($"QueryString: {request.QueryString}");

            context.Response.OnStarting(() => {
                Console.WriteLine("=============================");
                Console.WriteLine("========Response=========");
                System.Console.WriteLine(context.Response.StatusCode);
                return Task.CompletedTask; });

            await _next(context);
        }
    }
}
