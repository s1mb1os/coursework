﻿using CargoTransportation.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoTransportation.Middleware
{
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate _next;

        public DbInitializerMiddleware(RequestDelegate next)
        {
            // инициализация базы данных
            _next = next;
        }

        public Task Invoke(HttpContext context, IServiceProvider serviceProvider, CargoTransportationContext dbContext)
        {
            if (!context.Session.Keys.Contains("starting"))
            {
                DbInitializer.Initialize(dbContext);
                context.Session.SetString("starting", "Yes");
            }

            // Call the next delegate/middleware in the pipeline
            return _next.Invoke(context);
        }

    }
}
