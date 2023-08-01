using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TodoList.Api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TimingMiddleware> _logger;

        public TimingMiddleware(ILogger<TimingMiddleware> logger, RequestDelegate next)
        {
            _next = next;
            _logger= logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var start = DateTime.UtcNow;
            await _next(httpContext);
            _logger.LogInformation($"Request {httpContext.Request.Path}: {(DateTime.UtcNow-start).TotalMilliseconds} ");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TimingMiddlewareExtensions
    {
        public static IApplicationBuilder UseTimingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimingMiddleware>();
        }
    }
}
