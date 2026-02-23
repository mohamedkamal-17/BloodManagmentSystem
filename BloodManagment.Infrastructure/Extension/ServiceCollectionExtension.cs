using BloodManagment.Application.Commane;
using BloodManagment.Application.Extension;
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.Comman;
using BloodManagment.Infrastructure.DataHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BloodManagment.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection InfrastructureServiceCollectionExtension(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.AddScoped<IIdentityService, JwtProvider>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = AuthSchemes.Cookie;
                options.DefaultChallengeScheme = AuthSchemes.Cookie;
            })
            .AddCookie(AuthSchemes.Cookie, options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            })
            .AddJwtBearer(AuthSchemes.Jwt, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])),
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"]
                };
            });

            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserService>();





            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cs"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.AllowedUserNameCharacters =
                     "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._ ";
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
            })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
