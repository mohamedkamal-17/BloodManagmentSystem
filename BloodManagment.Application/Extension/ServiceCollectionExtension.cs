using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using System.Reflection;

namespace BloodManagment.Application.Extension
{
    public static class ServiceCollectionExtension
    {


        public static IServiceCollection ApplicationServiceCollectionExtension(
            this IServiceCollection services
            )
        {
            services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMailKit(config =>
            {
                config.UseMailKit(new MailKitOptions()
                {
                    Server = "smtp.gmail.com",
                    Port = 587,
                    SenderName = "Blood Management",
                    SenderEmail = "your@email.com",

                });
            });


            return services;
        }
    }
}
