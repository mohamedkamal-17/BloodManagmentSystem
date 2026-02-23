using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.Donarfeat.Queries.GetByUserId
{
    public class DonarDto
    {
        public string FullName { get; set; }
        public string DonarCode { get; set; }
        public DateTime? NextDonationDate { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public Gender Gender { get; set; }

        public DateTime? LastDonationDate { get; set; }

        public short DonationCount { get; set; } = default;

        public bool IsEilgibleToDonate { get; set; } = default;

    }
}