using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BloodManagment.Application.features.Auth.Commandes.MvcLogin
{
    public class MvcLoginCommand : IRequest<SignInResult>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}
