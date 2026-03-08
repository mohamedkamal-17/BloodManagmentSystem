using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetAllBloodUnits
{
    public class GetAllBloodUnitsSpec : Specefication<BloodUnit>
    {
        public GetAllBloodUnitsSpec() : base(x => true)
        {
            Includes.Add(x => x.BloodInventory);
        }
    }
}
