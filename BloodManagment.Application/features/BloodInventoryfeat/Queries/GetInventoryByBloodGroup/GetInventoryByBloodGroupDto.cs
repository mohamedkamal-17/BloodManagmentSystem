using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetInventoryByBloodGroup
{
    public class GetInventoryByBloodGroupDto
    {
        public int Quantity { get; set; }

        public BloodGroup BloodGroup { get; set; }


        public InventoryStatus Status { get; set; }
    }
}
