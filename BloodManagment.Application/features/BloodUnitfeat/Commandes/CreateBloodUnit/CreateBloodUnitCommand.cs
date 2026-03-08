using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Commandes.CreateBloodUnit
{
    public class CreateBloodUnitCommand : IRequest<int>
    {
        public BloodGroup BloodGroup { get; set; }

        public DateTime DonationDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string StorageLocation { get; set; }

        public int BloodInventoryId { get; set; }
    }
}
