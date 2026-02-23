using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.NewFolder
{
    public class CreateAnemiaBloodRequestCommandHandler
        : IRequestHandler<CreateAnemiaBloodRequestCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateAnemiaBloodRequestCommandHandler(IUnitOfWork unitOfWork)
        {

            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            CreateAnemiaBloodRequestCommand request,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Validate Patient Exists
            var patient = await unitOfWork.ThalassemiaPatientRepository
                .GetByIdAsync(request.PatientId);

            if (patient == null)
                throw new NotFoundException("Patient not found");

            // 2️⃣ Business Rule Validation (Important 🔥)


            // 3️⃣ Generate Request Code
            var requestCode = $"AN-{DateTime.UtcNow:yyyyMMddHHmmssfff}";

            // 4️⃣ Create Entity
            var anemiaRequest = new AnemiaBloodRequest
            {
                RequestCode = requestCode,
                RequestDate = DateTime.UtcNow,
                BloodGroup = request.BloodGroup,
                Status = RequestStatus.Pending,

                ResponsibleEntity = request.ResponsibleEntity,
                AttendanceDate = request.AttendanceDate,
                BloodTestDate = request.BloodTestDate,
                LastTransfusionDate = request.LastTransfusionDate,
                HemoglobinLevel = request.HemoglobinLevel,
                BloodTestIssuer = request.BloodTestIssuer,

                PatientId = request.PatientId
            };

            // 5️⃣ Add to Repository
            await unitOfWork.AnemiaBloodRequestRepository.AddAsync(anemiaRequest);

            // 6️⃣ Save Changes
            await unitOfWork.SaveChangesAsync();

            return anemiaRequest.Id;
        }
    }
}
