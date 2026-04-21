using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.AssignDonorToThalassemiaPatient
{
    public class AssignDonorToThalassemiaPatientCommandHandler
     : IRequestHandler<AssignDonorToThalassemiaPatientCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignDonorToThalassemiaPatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            AssignDonorToThalassemiaPatientCommand request,
            CancellationToken cancellationToken)
        {
            // ✅ Validate Patient
            var patient = await _unitOfWork.ThalassemiaPatientRepository
                .GetByIdAsync(request.ThalassemiaPatientId);

            if (patient == null)
                throw new Exception("Patient not found");

            // ✅ Validate Donor
            var donor = await _unitOfWork.DonarRepository
                .GetByIdAsync(request.DonarId);

            if (donor == null)
                throw new Exception("Donor not found");

            // ✅ Prevent duplicate
            var exists = await _unitOfWork
                .ThalassemiaPatientDonorAssignementRepository
                .ExistsAsync(request.ThalassemiaPatientId, request.DonarId);

            if (exists)
                throw new Exception("Already assigned");

            // 🧬 Create
            var entity = new ThalassemiaPatientDonorAssignement
            {
                ThalassemiaPatientId = request.ThalassemiaPatientId,
                DonarId = request.DonarId
            };

            await _unitOfWork
                .ThalassemiaPatientDonorAssignementRepository
                .AddAsync(entity);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
