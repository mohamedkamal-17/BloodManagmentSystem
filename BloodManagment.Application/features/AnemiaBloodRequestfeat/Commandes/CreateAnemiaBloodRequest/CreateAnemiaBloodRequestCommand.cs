using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.NewFolder
{

    public class CreateAnemiaBloodRequestCommand : IRequest<string>
    {
        public DateTime DiagnosisDate { get; set; }
        public DateTime LastTransfusionDate { get; set; }

        
        public int HospitalId { get; set; }

        // public string FullName { get; set; }
       
        public string? UserId { get; set; } 
        public BloodGroup BloodGroup { get; set; }

        // Case Information
        public string ResponsibleEntity { get; set; } = null!;
        public DateTime AttendanceDate { get; set; }
        public DateTime BloodTestDate { get; set; }
       
        public float HemoglobinLevel { get; set; }
        public string BloodTestIssuer { get; set; } = null!;
        public int? PatientId { get; set; }
    }
}
