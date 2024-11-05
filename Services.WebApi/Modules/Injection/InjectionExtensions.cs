﻿using Services.WebApi.Modules.GlobalException;
using Transversal.Common;
using Transversal.Logging;

namespace Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<GlobalExceptionHandler>();
            
            return services;
        }
    }
}
