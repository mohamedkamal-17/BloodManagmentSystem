using AutoMapper;
using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Commandes.CreatBloodRequest
{
    internal class CreateBloodRequestCommandHandler
    {


        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public CreateBloodRequestCommandHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {

            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }

        public async Task<string> Handle(
            CreatBloodRequestCommand request,
            CancellationToken cancellationToken)
        {

            var hospital = await unitOfWorke.HospitalRepository.GetByIdAsync(request.HospitalId);

            if (hospital == null)
                throw new Exception("Hospital not found");

            // 2️⃣ Validate Recipient (if exists)

            // 3️⃣ Generate Request Code (Senior Approach)
            var requestCode = $"BR-{DateTime.UtcNow:yyyyMMddHHmmssfff}";

            var brequest = mapper.Map<CreatBloodRequestCommand, BloodRequest>(request);
            // 4️⃣ Create Entity
            var bloodRequest = new BloodRequest
            {
                RequestCode = requestCode,
                RequestDate = request.RequestDate,
                IsEmergency = request.IsEmergency,
                HospitalId = request.HospitalId,
                Reason = request.Reason,
                RescipientId = request.RescipientId,
                LabTechnicianId = request.LabTechnicianId,
                BloodGroup = request.BloodGroup,
                Status = RequestStatus.Pending
            };

            // 5️⃣ Add to Repository
            await unitOfWorke.BloodRequestRepository.AddAsync(bloodRequest);

            // 6️⃣ Commit Transaction
            await unitOfWorke.SaveChangesAsync();

            return requestCode;
        }
    }
}
