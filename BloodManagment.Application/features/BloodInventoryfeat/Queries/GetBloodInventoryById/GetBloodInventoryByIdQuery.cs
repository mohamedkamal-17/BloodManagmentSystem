using MediatR;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetBloodInventoryById
{
    public class GetBloodInventoryByIdQuery
    : IRequest<BloodInentoriesDto>
    {
        public int Id { get; set; }
    }
}
