using BloodManagment.Application.Commane;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BloodManagment.Infrastructure.Comman
{

    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId =>
            _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier)
            ?? string.Empty;

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext?
                .User?
                .Identity?
                .IsAuthenticated ?? false;

        public string? Email =>
            _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.Email);

        public IEnumerable<string> Roles =>
            _httpContextAccessor.HttpContext?
                .User?
                .FindAll(ClaimTypes.Role)
                .Select(r => r.Value)
            ?? Enumerable.Empty<string>();
    }
}
