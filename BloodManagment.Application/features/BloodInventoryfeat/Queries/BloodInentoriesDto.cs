using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries
{
    public class BloodInentoriesDto
    {
        public int Quantity { get; set; }

        public BloodGroup BloodGroup { get; set; }


        public InventoryStatus Status { get; set; }
    }
}
