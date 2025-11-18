using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class BloodUnit : BaseEntity
    {


        public BloodGroup BloodGroup { get; set; }

        public DateTime DonationDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public BloodUnitStatus Status { get; set; } = BloodUnitStatus.Available;

        public string StorageLocation { get; set; }
    }
}
