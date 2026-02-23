using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Commandes.CreateThalassemiaPatientProfile
{

    public class CreateThalassemiaPatientProfileCommand : IRequest<int>
    {
        public DateTime DiagnosisDate { get; set; }

        public DateTime LastTransfusionDate { get; set; }

        public int HospitalId { get; set; }

        public string UserId { get; set; } = null!;
    }
}
