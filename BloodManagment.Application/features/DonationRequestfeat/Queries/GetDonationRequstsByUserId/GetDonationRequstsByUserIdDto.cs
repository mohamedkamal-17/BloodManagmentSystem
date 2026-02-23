using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByUserId
{
    public class GetDonationRequstsByUserIdDto
    {
        public string RequestCode { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime PreferredDonationDate { get; set; }


        public RequestStatus Statu { get; set; } = RequestStatus.Pending;

        public int HealthConditionId { get; set; }

        public int DonarId { get; set; }

        public string DonarName { get; set; }
    }
}
