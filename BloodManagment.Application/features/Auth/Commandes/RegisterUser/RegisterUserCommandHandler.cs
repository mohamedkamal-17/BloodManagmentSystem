using BloodManagment.domain.Entities;
using MediatR;

using Microsoft.AspNetCore.Identity;

namespace BloodManagment.Application.features.Auth.Commandes.LoginUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, String>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }


        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName,
                UserType = request.UserType
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new ApplicationException(
                    string.Join(", ", result.Errors.Select(e => e.Description)));

            return user.Id;
        }

    }
}

