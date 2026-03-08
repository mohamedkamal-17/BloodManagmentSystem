using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByInventoryId
{
    public class GetBloodUnitsByInventoryIdQuery
    : IRequest<IReadOnlyList<BloodUnitDTO>>
    {
        public int InventoryId { get; set; }

        public GetBloodUnitsByInventoryIdQuery(int inventoryId)
        {
            InventoryId = inventoryId;
        }
    }
}
