using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetAvailableBloodUnits
{
    public class GetAvailableBloodUnitsQuery
     : IRequest<IReadOnlyList<BloodUnit>>
    {
    }
}
