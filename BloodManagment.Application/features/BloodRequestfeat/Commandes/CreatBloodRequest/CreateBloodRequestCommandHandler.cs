using AutoMapper;
using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Commandes.CreatBloodRequest
{
    internal class CreateBloodRequestCommandHandler : IRequestHandler<CreatBloodRequestCommand, int>
    {


        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public CreateBloodRequestCommandHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {

            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }



        async Task<int> IRequestHandler<CreatBloodRequestCommand, int>.Handle(CreatBloodRequestCommand request, CancellationToken cancellationToken)
        {

            var hospital = await unitOfWorke.HospitalRepository.GetByIdAsync(request.HospitalId);

            if (hospital == null)
                throw new Exception("Hospital not found");

            // 2️⃣ Validate Recipient (if exists)

            // 3️⃣ Generate Request Code (Senior Approach)
            var requestCode = $"BR-{DateTime.UtcNow:yyyyMMddHHmmssfff}";

            var brequest = mapper.Map<CreatBloodRequestCommand, BloodRequest>(request);
            brequest.RequestCode = requestCode;
            // 4️⃣ Create Entity


            // 5️⃣ Add to Repository
            await unitOfWorke.BloodRequestRepository.AddAsync(brequest);

            // 6️⃣ Commit Transaction


            return await unitOfWorke.SaveChangesAsync();
        }
    }
}
