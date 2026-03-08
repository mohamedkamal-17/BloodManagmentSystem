using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetAllBloodUnits
{
    public class GetAllBloodUnitsQuery : IRequest<IReadOnlyList<BloodUnitDTO>>
    {
    }
}
