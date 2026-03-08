using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Commandes.DeleteBloodUnit
{
    public class DeleteBloodUnitCommand : IRequest
    {
        public int Id { get; set; }
    }
}
