using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestesByBloodStatu
{
    public class GetBloodRequestesByStatuSpc
        : Specefication<BloodRequest>
    {
        public GetBloodRequestesByStatuSpc(RequestStatus status) : base(request => request.Status == status)
        {

        }
    }
}
