using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class LabTechnician : BaseEntity
    {
        public DateTime HireDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }


        public ICollection<BloodRequest> BloodRequests { get; set; }
    }
}
