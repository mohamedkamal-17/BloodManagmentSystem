using BloodManagment.Application.Commane;
using BloodManagment.Application.features.ThalassemiaPatientfeat.Commandes.CreateThalassemiaPatientProfile;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.NewFolder
{
    public class CreateAnemiaBloodRequestCommandHandler
        : IRequestHandler<CreateAnemiaBloodRequestCommand, string>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;

        public CreateAnemiaBloodRequestCommandHandler(IUnitOfWork unitOfWork ,IMediator mediator)
        {

          
             this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        public async Task<string> Handle(
            CreateAnemiaBloodRequestCommand request,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Validate Patient Exists
            var patient = await unitOfWork.ThalassemiaPatientRepository
                .GetByUserIdAsync(request.UserId);

            if (patient == null)
            {
                await mediator.Send(new CreateThalassemiaPatientProfileCommand
                {
                    BloodGroup = request.BloodGroup,
                    DiagnosisDate = request.DiagnosisDate,
                    HospitalId = request.HospitalId,
                    LastTransfusionDate = request.LastTransfusionDate,
                   UserId = request.UserId



                });




            }
            patient = await unitOfWork.ThalassemiaPatientRepository
                .GetByUserIdAsync(request.UserId);
            if (patient is null) return null;

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
                Patient= patient

            };

            // 5️⃣ Add to Repository
            await unitOfWork.AnemiaBloodRequestRepository.AddAsync(anemiaRequest);

            // 6️⃣ Save Changes
            await unitOfWork.SaveChangesAsync();

            return anemiaRequest.Id.ToString();
        }
    }
}
