using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodInventoryfeat.Commandes.UpdateBloodInventory
{
    public class UpdateBloodInventoryCommandHandler
    : IRequestHandler<UpdateBloodInventoryCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateBloodInventoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }




        public async Task Handle(UpdateBloodInventoryCommand request, CancellationToken cancellationToken)
        {

            var inventory = await unitOfWork.BloodInventoryRepository.g

            if (inventory == null)
                throw new NotFoundException("Inventory not found");

            inventory.Quantity = request.Quantity;

            _unitOfWork.Repository<BloodInventory>().Update(inventory);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;


        }


    }
}


