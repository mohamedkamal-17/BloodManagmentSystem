using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class DonationRequest : BaseEntity
    {
        public string RequestCode { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime PreferredDonationDate { get; set; }


        public RequestStatus Statu { get; set; } = RequestStatus.Pending;

        public int HealthConditionId { get; set; }
        public HealthCondition HealthCondition { get; set; }
        public int DonarId { get; set; }
        public Donar Donar { get; set; }


    }
}
