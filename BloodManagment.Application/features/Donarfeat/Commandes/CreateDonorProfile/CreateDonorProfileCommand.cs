using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.Donarfeat.Commandes.CreateDonor
{
    public class CreateDonorProfileCommand
        : IRequest<int>
    {
        public string FullName { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public Gender Gender { get; set; }

        public DateTime? LastDonationDate { get; set; }
    }
}
