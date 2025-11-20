using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class BloodInventory : BaseEntity
    {

        public int Quantity { get; set; }

        public BloodGroup BloodGroup { get; set; }


        public InventoryStatus Status { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public ICollection<BloodUnit> BloodUnits { get; set; } = new HashSet<BloodUnit>();

    }
}
