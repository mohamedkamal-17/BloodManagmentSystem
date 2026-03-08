using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByInventoryId
{
    public class GetBloodUnitsByInventoryIdSpec : Specefication<BloodUnit>
    {
        public GetBloodUnitsByInventoryIdSpec(int inventoryId)
            : base(x => x.BloodInventoryId == inventoryId)
        {
            Includes.Add(x => x.BloodInventory);
        }
    }
}
