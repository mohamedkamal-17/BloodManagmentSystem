using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetBloodInventoryById
{
    public class GetBloodInventoryByIdSpec
    : Specefication<BloodInventory>
    {
        public GetBloodInventoryByIdSpec(int id)
            : base(i => i.Id == id)
        {
            Includes.Add(i => i.Hospital);
            Includes.Add(i => i.BloodUnits);
        }
    }
}
