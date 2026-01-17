using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetInventoryByBloodGroup
{
    public class GetInventoryByBloodGroupSpc : Specefication<BloodInventory>
    {
        public GetInventoryByBloodGroupSpc(BloodGroup bloodGroup) : base(inv => inv.BloodGroup == bloodGroup)
        {
        }
    }
}
