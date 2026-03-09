using BloodManagment.domain.Entities;

namespace BloodManagment.Mvc.ViewModels.BloodRequests
{
    public class BloodRequestCardVM
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public string Reason { get; set; }

        public DateTime RequestDate { get; set; }

        public bool IsEmergency { get; set; }

        public RequestStatus Status { get; set; }

        public string HospitalName { get; set; }

        public string UserImage { get; set; }
    }
}
