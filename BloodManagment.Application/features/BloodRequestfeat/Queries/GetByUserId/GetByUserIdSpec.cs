using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByUserId
{
    public class GetByUserIdSpec : Specefication<BloodRequest>
    {
        public GetByUserIdSpec(int userId) : base(request => request.RescipientId == userId)
        {

        }
    }
}
