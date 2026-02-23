using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BloodManagment.Application.features.Auth.Commandes.ApiLogin
{
    public class ApiLoginCommand : IRequest<string>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
