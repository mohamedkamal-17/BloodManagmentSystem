using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByRecipientId
{
    public class GetByRecipientIdSpec : Specefication<BloodRequest>
    {
        public GetByRecipientIdSpec(int userId) : base(request => request.RescipientId == userId)
        {

        }
    }
}
