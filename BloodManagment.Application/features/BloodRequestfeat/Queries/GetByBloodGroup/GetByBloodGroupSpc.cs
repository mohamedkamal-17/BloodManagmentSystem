using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByBloodGroup
{
    public class GetByBloodGroupSpc : Specefication<BloodRequest>
    {
        public GetByBloodGroupSpc(BloodGroup bloodGroup) : base(request => request.BloodGroup == bloodGroup)
        {


        }
    }
}
