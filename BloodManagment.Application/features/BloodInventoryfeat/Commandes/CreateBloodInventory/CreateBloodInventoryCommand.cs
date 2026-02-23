using BloodManagment.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.BloodInventoryfeat.Commandes.CreateBloodInventory
{
    public class CreateBloodInventoryCommand : IRequest<int>
    {
        public int Quantity { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public InventoryStatus Status { get; set; }
        public int HospitalId { get; set; }
    }
}
