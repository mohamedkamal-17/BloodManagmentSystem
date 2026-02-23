using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodInventoryfeat.Commandes.CreateBloodInventory
{
    public class CreateBloodInventoryCommandHandler
     : IRequestHandler<CreateBloodInventoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBloodInventoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            CreateBloodInventoryCommand request,
            CancellationToken cancellationToken)
        {
            var inventory = new BloodInventory
            {
                Quantity = request.Quantity,
                BloodGroup = request.BloodGroup,
                Status = request.Status,
                HospitalId = request.HospitalId
            };

            await _unitOfWork.BloodInventoryRepository.AddAsync(inventory);

            await _unitOfWork.SaveChangesAsync();

            return inventory.Id;
        }
    }
}
