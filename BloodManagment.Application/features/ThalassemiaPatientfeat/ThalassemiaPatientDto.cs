using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat
{
    public class ThalassemiaPatientDto
    {
        public int Id { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public DateTime LastTransfusionDate { get; set; }
        public DateTime NextTransfusionDate { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public string HospitalName { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
    }
}
