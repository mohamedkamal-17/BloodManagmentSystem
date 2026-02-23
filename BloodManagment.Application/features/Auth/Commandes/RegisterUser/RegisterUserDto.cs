using BloodManagment.domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BloodManagment.Application.features.Auth.Commandes.RegisterUser
{
    public class RegisterUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public UserType UserType { get; set; }
    }
}
