using BloodManagment.Application.Commane;
using MediatR;


namespace BloodManagment.Application.features.BloodUnitfeat.Commandes.DeleteBloodUnit
{
    public class DeleteBloodUnitCommandHandler
     : IRequestHandler<DeleteBloodUnitCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBloodUnitCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

     

        async Task IRequestHandler<DeleteBloodUnitCommand>.Handle(DeleteBloodUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await _unitOfWork
                .BloodUnitRepository
                .GetByIdAsync(request.Id);

            if (unit == null)
                throw new KeyNotFoundException("Blood unit not found");

            _unitOfWork.BloodUnitRepository.DeleteAsync(unit);

            await _unitOfWork.SaveChangesAsync();

        }
    }
}
