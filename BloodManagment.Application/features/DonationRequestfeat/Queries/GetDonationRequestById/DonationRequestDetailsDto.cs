using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById
{
    public class DonationRequestDetailsDto
    {
        public int Id { get; set; }
        public string RequestCode { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime PreferredDonationDate { get; set; }


        public RequestStatus Statu { get; set; } = RequestStatus.Pending;

        public int HealthConditionId { get; set; }

        public int DonarId { get; set; }

        public string DonarName { get; set; }
        public HealthCondition HealthCondition { get; set; }
    }
}
