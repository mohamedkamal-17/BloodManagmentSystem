using BloodManagment.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Auth.Commandes.ApiLogin
{
    public class LoginRespons
    {
        public string UserId { get; set; }

        // UserType to determine what role the user has (Donor, Admin, etc.)
        public UserType UserType { get; set; }

        // Additional properties you can add for login (email, password, etc.)
    
     
    }
}
