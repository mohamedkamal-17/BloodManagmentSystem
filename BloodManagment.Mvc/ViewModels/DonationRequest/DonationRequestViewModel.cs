using BloodManagment.domain.Entities;

namespace BloodManagment.Mvc.ViewModels.DonationRequest
{
    public class DonationRequestViewModel
    {
        public int Id { get; set; }
        public string RequestCode { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime PreferredDonationDate { get; set; }

        public RequestStatus Status { get; set; }

        public int HealthConditionId { get; set; }

        public int DonarId { get; set; }

        public string DonarName { get; set; }
    }
}
