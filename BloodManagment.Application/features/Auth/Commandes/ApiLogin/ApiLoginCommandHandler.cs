using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BloodManagment.Application.features.Auth.Commandes.ApiLogin
{
    public class ApiLoginCommandHandler : IRequestHandler<ApiLoginCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityService _tokenService;

        public ApiLoginCommandHandler(
            UserManager<ApplicationUser> userManager,
            IIdentityService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(
            ApiLoginCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null ||
                !await _userManager.CheckPasswordAsync(user, request.Password))
                throw new UnauthorizedAccessException();

            return await _tokenService.CreateToken(user);
        }
    }
}
