using BloodManagment.Application.features.Donarfeat.Commandes.CreateDonor;
using BloodManagment.Application.features.Rescipientfeat.Commandes.CreateRescipientProfile;
using BloodManagment.domain.Entities;
using MediatR;

using Microsoft.AspNetCore.Identity;

namespace BloodManagment.Application.features.Auth.Commandes.LoginUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, String>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMediator mediator;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager,IMediator mediator)
        {
            this.userManager = userManager;
            this.mediator = mediator;
        }


        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.FullName,
                Email = request.Email,
                FullName = request.FullName,
                UserType = UserType.Donor
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new ApplicationException(
                    string.Join(", ", result.Errors.Select(e => e.Description)));
            
                // create donor profile
                await mediator.Send(new CreateDonorProfileCommand
                {
                    BloodGroup= BloodGroup.A_Positive,
                    UserId = user.Id,
                    Gender =Gender.Male,
                    LastDonationDate= DateTime.Now.AddMonths(-3) // ⚠️ you can pass from request later
                });
            
            
                await mediator.Send(new CreateRescipientProfileCommand
                {
                    UserId = user.Id,

                    Gender = Gender.Male // ⚠️ you can pass from request later
                });
       
            

            return user.Id;
        }

    }
}

