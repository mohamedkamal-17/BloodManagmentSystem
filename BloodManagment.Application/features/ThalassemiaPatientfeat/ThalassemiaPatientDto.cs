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

        public int HospitalId { get; set; }   // ✅ useful for future operations
        public string? HospitalName { get; set; }

         public string? FullName { get; set; } = null!;
    }
}
