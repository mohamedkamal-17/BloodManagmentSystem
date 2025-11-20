using BloodManagment.domain.Common;

namespace BloodManagment.domain.Entities
{
    public class ThalassemiaPatient : BaseEntity
    {

        public DateTime DiagnosisDate { get; set; }
        public DateTime LastTransfusionDate { get; set; }
        public DateTime NextTransfusionDate { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<ThalassemiaPatientDonorAssignement> thalassemiaPatientDonorAssignements { get; set; } = new HashSet<ThalassemiaPatientDonorAssignement>();

    }
}
