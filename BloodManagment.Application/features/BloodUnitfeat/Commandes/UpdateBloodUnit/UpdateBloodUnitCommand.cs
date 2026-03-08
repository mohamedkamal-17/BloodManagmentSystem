using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Commandes.UpdateBloodUnit
{
    public class UpdateBloodUnitCommand : IRequest
    {
        public int Id { get; set; }
        public BloodUnitStatus BloodUnitStatus { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string StorageLocation { get; set; }
    }
}
