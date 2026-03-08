using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestesByBloodStatus
{
    public class GetBloodRequestesByStatuDto
    {

        public string RequestCode { get; set; }
        public DateTime RequestDate { get; set; }
        public string HospitalName { get; set; }

        public bool IsEmergency { get; set; }
        public int HospitalId { get; set; }

        public string Reason { get; set; }
        public string PatientName { get; set; }
        public int? RescipientId { get; set; }


        public BloodGroup BloodGroup { get; set; }

        public RequestStatus Status { get; set; }
    }
}