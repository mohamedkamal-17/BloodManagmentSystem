using BloodManagment.domain.Entities;
using MediatR;


namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetInventoryByBloodGroup
{

    public class GetInventoryByBloodGroupQuery
    : IRequest<GetInventoryByBloodGroupDto>
    {
        public BloodGroup BloodGroup { get; set; }

        public GetInventoryByBloodGroupQuery(BloodGroup bloodGroup)
        {
            BloodGroup = bloodGroup;
        }
    }
}
