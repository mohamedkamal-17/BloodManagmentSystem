namespace BloodManagment.Application.features.Donarfeat.Commandes.DeleteDonor
{
    using BloodManagment.Application.Commane;
    using MediatR;

    public class DeleteDonorCommandHandler
        : IRequestHandler<DeleteDonorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDonorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
            DeleteDonorCommand request,
            CancellationToken cancellationToken)
        {
            // 🔍 Step 1: Get donor
            var donor = await _unitOfWork.DonarRepository.GetByIdAsync(request.Id);

            if (donor == null)
                throw new Exception("Donor not found");

            // ⚠️ Step 2: Check relations (important 🔥)
            if (donor.thalassemiaPatientDonorAssignements.Any())
                throw new Exception("Cannot delete donor with existing assignments");

            // 🗑 Step 3: Delete
            _unitOfWork.DonarRepository.DeleteAsync(donor);

            // 💾 Step 4: Save
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
