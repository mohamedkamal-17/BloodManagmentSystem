using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Commandes.AcceptBloodRequest
{
    public class AcceptBloodRequestCommandHandler
     : IRequestHandler<AcceptBloodRequestCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public AcceptBloodRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            AcceptBloodRequestCommand request,
            CancellationToken cancellationToken)
        {
            var bloodRequest = await unitOfWork.BloodRequestRepository.GetByIdAsync(request.Id);

            if (bloodRequest == null)
                return false;

            bloodRequest.Status = RequestStatus.Accepted; // Accepted

            await unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
