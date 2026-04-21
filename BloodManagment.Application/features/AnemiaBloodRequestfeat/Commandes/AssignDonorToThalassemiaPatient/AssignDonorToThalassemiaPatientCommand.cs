using MediatR;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.AssignDonorToThalassemiaPatient
{
    public class AssignDonorToThalassemiaPatientCommand : IRequest<bool>
    {
        public int ThalassemiaPatientId { get; set; }
        public int DonarId { get; set; }
    }
}
