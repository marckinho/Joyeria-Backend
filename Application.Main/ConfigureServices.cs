using Application.Validator;
using ApplicationUseCases.Customers;
using ApplicationUseCases.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationUseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            /*services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IDiscountApplication, DiscountApplication>();*/

            services.AddTransient<UsersDtoValidator>();
            services.AddTransient<DiscountDtoValidator>();

            return services;
        }
    }
}
