﻿using Microsoft.Extensions.DependencyInjection;
using TourManager.Domain.Abstract;
using TourManager.Domain.Logic;

namespace TourManager.Domain
{
    public class DiExtension
    {
        public static void AddDI(IServiceCollection services)
        {
            services.AddScoped<ITouristManager, TouristManager>();
            services.AddScoped<ITourManager, Logic.TourManager>();
        }
    }
}