using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByBloodGroup
{
    public class GetBloodUnitsByBloodGroupSpec : Specefication<BloodUnit>
    {
        public GetBloodUnitsByBloodGroupSpec(BloodGroup bloodGroup)
            : base(x => x.BloodGroup == bloodGroup)
        {
            Includes.Add(x => x.BloodInventory);
        }
    }
}
