using AutoMapper;
using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Commandes.CreatBloodRequest
{
    internal class CreateBloodRequestCommandHandler : IRequestHandler<CreatBloodRequestCommand, string>
    {


        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public CreateBloodRequestCommandHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {

            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }

        public async Task<string> Handle(CreatBloodRequestCommand request, CancellationToken cancellationToken)
        {
            var hospital = await unitOfWorke.HospitalRepository.GetByIdAsync(request.HospitalId);

            if (hospital == null)
                return null;


            var patient = await unitOfWorke.RecipientRepository.GetByUserIdAsync(request.UserId);
            if (patient == null) return null;

            // 2️⃣ Validate Recipient (if exists)

            // 3️⃣ Generate Request Code (Senior Approach)
            var requestCode = $"BR-{DateTime.UtcNow:yyyyMMddHHmmssfff}";
            request.RescipientId = patient.Id;

            var brequest = new BloodRequest
            {
                RequestCode = requestCode,
                HospitalId = request.HospitalId,
                RescipientId = patient.Id,
                BloodGroup = request.BloodGroup,

                IsEmergency = request.IsEmergency,

                RequestDate = DateTime.UtcNow,
                Status = RequestStatus.Pending,
                Reason = request.Reason,



            };



            // 4️⃣ Create Entity


            // 5️⃣ Add to Repository
            await unitOfWorke.BloodRequestRepository.AddAsync(brequest);

            // 6️⃣ Commit Transaction


            await unitOfWorke.SaveChangesAsync();

            return brequest.Id.ToString();
        }

        }
}
