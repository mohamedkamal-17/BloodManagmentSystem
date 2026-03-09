using BloodManagment.domain.Entities;

namespace BloodManagment.Mvc.ViewModels.BloodRequests
{
    public class BloodRequestDetailsVM
    {

        public int Id { get; set; }
        public string RequestNumber { get; set; }

        public string PatientName { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public string PhoneNumber { get; set; }

        public string Disease { get; set; }

        public string Hospital { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public RequestStatus Status { get; set; }
    }
}
