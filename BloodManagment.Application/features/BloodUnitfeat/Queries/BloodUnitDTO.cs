using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries
{
    public class BloodUnitDTO
    {
        public int Id { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public DateTime DonationDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public BloodUnitStatus Status { get; set; }

        public string StorageLocation { get; set; }

        public int BloodInventoryId { get; set; }
    }
}