using MediatR;

namespace BloodManagment.Application.features.Donarfeat.Commandes.UpdateDonor
{
    public class UpdateDonorCommand : IRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
