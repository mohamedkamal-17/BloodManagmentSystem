using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Commandes.CreateBloodUnit
{
    public class CreateBloodUnitCommandHandler
    : IRequestHandler<CreateBloodUnitCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBloodUnitCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            CreateBloodUnitCommand request,
            CancellationToken cancellationToken)
        {
            var unit = new BloodUnit
            {
                BloodGroup = request.BloodGroup,
                DonationDate = request.DonationDate,
                ExpiryDate = request.ExpiryDate,
                StorageLocation = request.StorageLocation,
                BloodInventoryId = request.BloodInventoryId,
                Status = BloodUnitStatus.Available
            };

            await _unitOfWork.BloodUnitRepository.AddAsync(unit);

            await _unitOfWork.SaveChangesAsync();

            return unit.Id;
        }
    }
}
