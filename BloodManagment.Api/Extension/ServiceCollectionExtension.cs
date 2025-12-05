using BloodManagment.Api.Comman;

namespace BloodManagment.Api.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection PresintationServiceCollectionExtension(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            return services;
        }
    }
}
