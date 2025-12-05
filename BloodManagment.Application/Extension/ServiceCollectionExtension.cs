using Microsoft.Extensions.DependencyInjection;

namespace BloodManagment.Application.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ApplicationServiceCollectionExtension(
            this IServiceCollection services
            )
        {

            return services;
        }
    }
}
