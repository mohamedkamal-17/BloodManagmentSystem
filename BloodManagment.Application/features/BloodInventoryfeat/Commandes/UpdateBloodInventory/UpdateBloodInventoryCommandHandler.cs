using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.BloodInventoryfeat.Commandes.UpdateBloodInventory
{

    public class UpdateBloodInventoryCommandHandler
        : IRequestHandler<UpdateBloodInventoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBloodInventoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        async Task IRequestHandler<UpdateBloodInventoryCommand>.Handle(UpdateBloodInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork
                 .BloodInventoryRepository
                 .GetByIdAsync(request.Id);

            if (inventory == null)
                throw new KeyNotFoundException("Blood inventory not found");

            inventory.Quantity = request.Quantity;

            await _unitOfWork.SaveChangesAsync();


        }
    }
}
