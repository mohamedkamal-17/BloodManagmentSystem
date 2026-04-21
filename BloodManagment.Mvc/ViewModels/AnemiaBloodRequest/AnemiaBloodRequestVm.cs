using BloodManagment.domain.Entities;

namespace BloodManagment.Mvc.ViewModels.AnemiaBloodRequest
{
    public class AnemiaBloodRequestVm
    {
        public int Id { get; set; }
        public string RequestCode { get; set; }
        public DateTime RequestDate { get; set; }

        public BloodGroup BloodGroup { get; set; }
        public RequestStatus Status { get; set; }

        public string ResponsibleEntity { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime BloodTestDate { get; set; }
        public DateTime LastTransfusionDate { get; set; }
        public float HemoglobinLevel { get; set; }
        public string BloodTestIssuer { get; set; }

        public int PatientId { get; set; }
    }
}
