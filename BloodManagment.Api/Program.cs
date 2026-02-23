using BloodManagment.Application.Extension;
using BloodManagment.Infrastructure.Extension;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BloodManagment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.InfrastructureServiceCollectionExtension(builder.Configuration);


            builder.Services.AddAuthentication(options =>
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
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"]
    };
});
            // Add services to the container.
            builder.Services.AddAuthorization();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();





            app.Run();
        }
    }
}
