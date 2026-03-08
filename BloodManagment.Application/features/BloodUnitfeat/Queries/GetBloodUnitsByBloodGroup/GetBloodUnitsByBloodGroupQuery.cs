using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByBloodGroup
{
    public class GetBloodUnitsByBloodGroupQuery
     : IRequest<IReadOnlyList<BloodUnitDTO>>
    {
        public BloodGroup BloodGroup { get; set; }

        public GetBloodUnitsByBloodGroupQuery(BloodGroup bloodGroup)
        {
            BloodGroup = bloodGroup;
        }
    }
}
