﻿using MedClinical.API.Data.Models.Auth;
using MedClinical.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace MedClinical.API.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private IAuthService _authService;

        public AuthMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //_authBl = context.RequestServices.GetService(typeof(IAuthBl)) as AuthBl;
            _authService = context.RequestServices.GetService<IAuthService>();

            AuthResultDto refreshResult = new AuthResultDto();
            var token = context.Request.Cookies[".AspNetCore.Application.Id"];
            if (!string.IsNullOrEmpty(token) && !IsExpiredAccess(token) && _authService != null)
            {
                var refreshToken = context.Request.Cookies[".AspNetCore.Application.Id-refresh"];
            }
            if (refreshResult.Success)
            {
                context.Request.Headers.Add("Authorization", "Bearer " + refreshResult.Token);
                context.Response.Cookies.Append(".AspNetCore.Application.Id", refreshResult.Token,
                    new CookieOptions
                    {
                    });
                context.Response.Cookies.Append(".AspNetCore.Application.Id-refresh", refreshResult.RefreshToken,
                    new CookieOptions
                    {
                        MaxAge = TimeSpan.FromHours(48)
                    });
            }
            else
            {
                if (!string.IsNullOrEmpty(token))
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
            }
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-Xss-Protection", "1");
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            Console.WriteLine("HANDLED AT: " + DateTime.Now.ToString());
            Console.WriteLine("Request: " + context.Request.Headers["Authorization"]);
            foreach (var cookie in context.Request.Cookies)
            {
                Console.WriteLine(cookie);
            }
            await _next.Invoke(context);
        }

        public bool IsExpiredAccess(string token)
        {
            return _authService.ValidateTokenExpiry(token);
        }
    }
}