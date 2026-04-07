using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetPendingDonationRequestByDonor
{
    public class PendingDonationRequestByDonorQuery : IRequest<DonationRequestDto>
    {
        public int DonorId
        {
            get; set;
        }
    }
}

