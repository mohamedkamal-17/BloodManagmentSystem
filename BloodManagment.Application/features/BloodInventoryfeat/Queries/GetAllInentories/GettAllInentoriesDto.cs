using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetAllInentory
{
    public class GettAllInentoriesDto
    {
        public int Quantity { get; set; }

        public BloodGroup BloodGroup { get; set; }


        public InventoryStatus Status { get; set; }
    }
}
