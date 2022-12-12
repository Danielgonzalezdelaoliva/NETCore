using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaApi
{
    public class MyCustomMiddleware1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom Middleware Incoming Request \n");
            await next(context);
            await context.Response.WriteAsync("Custom Middleware Outgoing Response \n");
        }
    }
}
