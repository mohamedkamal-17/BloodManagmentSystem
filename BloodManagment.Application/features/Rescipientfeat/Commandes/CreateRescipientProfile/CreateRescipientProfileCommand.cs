using BloodManagment.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Rescipientfeat.Commandes.CreateRescipientProfile
{
    public class CreateRescipientProfileCommand : IRequest<int>
    {
        public string UserId { get; set; }
      
        public Gender Gender { get; set; } = default;
    }
}
