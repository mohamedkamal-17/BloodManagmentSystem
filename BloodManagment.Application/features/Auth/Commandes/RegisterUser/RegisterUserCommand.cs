using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.Auth.Commandes.LoginUser
{
    public class RegisterUserCommand : IRequest<String>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public UserType UserType { get; set; }
    }
}
