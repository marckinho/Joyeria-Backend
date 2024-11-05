using Services.WebApi.Modules.GlobalException;

namespace Services.WebApi.Modules.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app) 
        { 
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
