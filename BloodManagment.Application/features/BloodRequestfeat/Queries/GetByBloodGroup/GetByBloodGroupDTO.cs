using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByBloodGroup
{
    public class GetByBloodGroupDTO
    {

        public string RequestCode { get; set; }
        public DateTime RequestDate { get; set; }

        public bool IsEmergency { get; set; }
        public int HospitalId { get; set; }

        public string Reason { get; set; }
        public int? RescipientId { get; set; }


        public BloodGroup BloodGroup { get; set; }

        public RequestStatus Status { get; set; }


    }
}
