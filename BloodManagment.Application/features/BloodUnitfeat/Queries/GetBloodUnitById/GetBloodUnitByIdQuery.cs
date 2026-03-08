using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitById
{
    public class GetBloodUnitByIdQuery : IRequest<BloodUnit>
    {
        public int Id { get; set; }
    }
}
