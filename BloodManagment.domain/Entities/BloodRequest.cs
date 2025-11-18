using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class BloodRequest : BaseEntity
    {
        public string RequestCode { get; set; }
        public DateTime RequestDate { get; set; }

        public bool IsEmergency { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public string Reason { get; set; }
        public string? RescipientId { get; set; }
        public Rescipient? Rescipient { get; set; }

        public string? LabTechnicianId { get; set; }
        public LabTechnician? LabTechnician { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public RequestStatus Status { get; set; } = RequestStatus.Pending;


    }
}
