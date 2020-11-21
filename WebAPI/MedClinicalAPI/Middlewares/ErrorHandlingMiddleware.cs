using MedClinicalAPI.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MedClinicalAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseCustomException baseEx)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(baseEx.Message);
                await HandleCustomExceptionAsync(context, baseEx);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                await HandleExceptionAsync(context, ex);
                Console.ResetColor();
            }
        }

        private Task HandleCustomExceptionAsync(HttpContext context, BaseCustomException baseEx)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)baseEx.Code;
            var exceptionResponse = JsonConvert.SerializeObject(new { StatusCode = baseEx.Code, Message = baseEx.Message });
            return context.Response.WriteAsync(exceptionResponse);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new { message = ex.Message });
            return context.Response.WriteAsync(result);
        }
    }
}