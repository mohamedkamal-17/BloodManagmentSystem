using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BloodManagment.Application.features.Auth.Commandes.MvcLogin
{
    public class MvcLoginCommandHandler : IRequestHandler<MvcLoginCommand, SignInResult>
    {

        private readonly SignInManager<ApplicationUser> _signInManager;

        public MvcLoginCommandHandler(
            SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Handle(
            MvcLoginCommand request,
            CancellationToken cancellationToken)
        {
            return await _signInManager.PasswordSignInAsync(
                request.Email,
                request.Password,
                request.RememberMe,
                lockoutOnFailure: true);
        }
    }
}
