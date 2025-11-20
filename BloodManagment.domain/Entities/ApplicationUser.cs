

using Microsoft.AspNetCore.Identity;

namespace BloodManagment.domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties can be added here as needed    
        public string FullName { get; set; }
        public UserType UserType { get; set; }
    }
}
