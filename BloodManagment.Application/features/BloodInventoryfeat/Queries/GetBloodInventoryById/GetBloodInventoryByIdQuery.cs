using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetBloodInventoryById
{
    public class GetBloodInventoryByIdQuery
    : IRequest<BloodInventory>
    {
        public int Id { get; set; }
    }
}
