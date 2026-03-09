namespace BloodManagment.Application.features.BloodRequestfeat.Commandes.DeleteBloodRequest
{
    using BloodManagment.Application.Commane;
    using MediatR;

    public class DeleteBloodRequestCommandHandler
        : IRequestHandler<DeleteBloodRequestCommand, bool>
    {

        private readonly IUnitOfWork unitOfWork;

        public DeleteBloodRequestCommandHandler(IUnitOfWork unitOfWork)
        {

            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            DeleteBloodRequestCommand request,
            CancellationToken cancellationToken)
        {
            var bloodRequest = await unitOfWork.BloodRequestRepository.GetByIdAsync(request.Id);

            if (bloodRequest == null)
                return false;

            bloodRequest.IsDeleted = true;

            await unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
