using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services,IConfiguration configuration)
        {
            string myPolicy = "policyAPI";

            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                                       .AllowAnyHeader()
                                                                                       .AllowAnyMethod()));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // Cambia si tienes otro origen
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials(); // Esto es opcional si necesitas enviar cookies o autenticación
                });
            });

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddMvc();
            services.AddControllers().AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });

            return services;
        }
    }
}
