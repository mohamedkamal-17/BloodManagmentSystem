using BloodManagment.domain.Entities;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestsByBloodGroup
{
    public class GetAnemiaBloodRequestByBloodGroupQuery : IRequest<ReadOnlyCollection<GetAnemiaBloodRequestByBloodGroupDto>>
    {
        public BloodGroup BloodGroup { get; set; }
    }
}
