using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetPendingDonationRequestByDonor
{
    public class GetPendingDonationRequestByDonorSpec : Specefication<DonationRequest>
    {
        public GetPendingDonationRequestByDonorSpec(int donorId) : base(x => x.Id == donorId
                         && x.Statu == RequestStatus.Pending)
        {
        }
    }
}
