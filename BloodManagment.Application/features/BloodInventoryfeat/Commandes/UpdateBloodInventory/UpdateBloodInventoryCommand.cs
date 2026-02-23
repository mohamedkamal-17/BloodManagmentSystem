using MediatR;

namespace BloodManagment.Application.features.BloodInventoryfeat.Commandes.UpdateBloodInventory
{
    public class UpdateBloodInventoryCommand : IRequest
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
