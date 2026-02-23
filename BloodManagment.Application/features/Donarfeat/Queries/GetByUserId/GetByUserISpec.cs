using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.Donarfeat.Queries.GetByUserId
{
    public class GetByUserISpec : Specefication<Donar>
    {
        public GetByUserISpec(string userId) : base(x => x.UserId == userId)
        {
        }
    }
}
