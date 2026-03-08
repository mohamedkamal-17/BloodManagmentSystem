using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetAvailableBloodUnits
{
    public class GetAvailableBloodUnitsSpec : Specefication<BloodUnit>
    {
        public GetAvailableBloodUnitsSpec()
            : base(x => x.Status == BloodUnitStatus.Available)
        {
            Includes.Add(x => x.BloodInventory);
        }
    }
}
