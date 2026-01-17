using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestsByBloodGroup
{
    public class GetAnemiaBloodRequestByBloodGroupSpc : Specefication<AnemiaBloodRequest>
    {
        public GetAnemiaBloodRequestByBloodGroupSpc(BloodGroup bloodGroup) : base(a => a.BloodGroup == bloodGroup)
        {

        }
    }
}
