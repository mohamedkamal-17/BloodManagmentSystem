using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace BloodManagment.Infrastructure.Comman
{
    public class JwtProvider : IIdentityService
    {
        protected readonly IConfiguration _configuration;
        public JwtProvider(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task<string> CreateToken(ApplicationUser user)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            var securtykey = new SymmetricSecurityKey(secretKeyBytes);

            var credentials = new SigningCredentials(securtykey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.Id),
                    new Claim("UserName", user.UserName),
                    new Claim("Email", user.Email),
                    new Claim(ClaimTypes.Role, user.UserType.ToString())

                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = credentials,

            };

            var tokenHandler = new JsonWebTokenHandler();

            return tokenHandler.CreateToken(tokenDescriptor);


        }


    }
}
