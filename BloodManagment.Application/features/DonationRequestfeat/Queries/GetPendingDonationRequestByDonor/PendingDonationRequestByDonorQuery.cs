using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetPendingDonationRequestByDonor
{
    public class PendingDonationRequestByDonorQuery : IRequest<PendingDonationRequestByDonorDto>
    {
        public int DonorId
        {
            get; set;
        }
    }
}

