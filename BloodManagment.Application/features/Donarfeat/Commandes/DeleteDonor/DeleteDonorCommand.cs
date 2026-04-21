using MediatR;

namespace BloodManagment.Application.features.Donarfeat.Commandes.DeleteDonor
{
    public class DeleteDonorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
