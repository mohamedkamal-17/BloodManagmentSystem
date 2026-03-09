using BloodManagment.domain.Entities;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByBloodGroup
{
    public class GetByBloodGroupQuery : IRequest<ReadOnlyCollection<BloodRequestDto>>
    {
        public BloodGroup BloodGroup { get; set; }
    }
}
