using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoreapp.Middlewares
{
    /// <summary>
    /// The Data Class that will be JSON Serialized in Http Response
    /// </summary>
    public class ErrorInfo
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// The Middleware logic class for Global Exceptions for WEB APIs 
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// The ctor will be part of Current HttpRequest using HttpContext
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        /// <summary>
        /// The Invoke Method for Middleware Logic
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                // If no exception then continue wil next middleware
               await _next(ctx);
            }
            catch (Exception ex)
            {
                await HandleException(ctx, ex);
            }
        }
        /// <summary>
        /// The Logic Method
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleException(HttpContext ctx, Exception exception)
        {
            // define the Response Type
            ctx.Response.StatusCode = 500;

            // Manage the Data Class for Error Message

            var errorInfo = new ErrorInfo()
            {
                ErrorCode =  ctx.Response.StatusCode,
                ErrorMessage = exception.Message
            };

            // Serialize the Response in JSON format
            string responseMessage = JsonConvert.SerializeObject(errorInfo);

            // Write the response
             return ctx.Response.WriteAsync(responseMessage);
        }
    }

    // The exception Middleware Extension Class

    public static class CustomExceptionMiddleware
    {
        /// <summary>
        /// Extension Method
        /// </summary>
        /// <param name="app"></param>
        public static void UseErrorMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

    }
}
