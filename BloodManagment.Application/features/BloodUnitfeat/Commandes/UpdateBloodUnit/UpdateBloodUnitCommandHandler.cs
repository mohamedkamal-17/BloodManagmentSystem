using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Commandes.UpdateBloodUnit
{
    public class UpdateBloodUnitCommandHandler
    : IRequestHandler<UpdateBloodUnitCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBloodUnitCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        async Task IRequestHandler<UpdateBloodUnitCommand>.Handle(UpdateBloodUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await _unitOfWork
                .BloodUnitRepository
                .GetByIdAsync(request.Id);

            if (unit == null)
                throw new KeyNotFoundException("Blood unit not found");

            unit.ExpiryDate = request.ExpiryDate;
            unit.StorageLocation = request.StorageLocation;
            unit.Status = request.BloodUnitStatus;

            _unitOfWork.BloodUnitRepository.UpdateAsync(unit);

            await _unitOfWork.SaveChangesAsync();


        }
    }
}
