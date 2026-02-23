using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

using Microsoft.AspNetCore.Identity;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Commandes.CreateThalassemiaPatientProfile
{
    public class CreateThalassemiaPatientProfileCommandHandler
    : IRequestHandler<CreateThalassemiaPatientProfileCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateThalassemiaPatientProfileCommandHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {

            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.userManager = userManager;
        }

        public async Task<int> Handle(
            CreateThalassemiaPatientProfileCommand request,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Validate Hospital Exists
            var hospital = await unitOfWork.HospitalRepository
                .GetByIdAsync(request.HospitalId);

            if (hospital == null)
                throw new NotFoundException("Hospital not found");

            // 2️⃣ Validate User Exists
            var user = await userManager.FindByIdAsync(request.UserId);





            // 4️⃣ Calculate Next Transfusion Date
            var nextTransfusionDate = request.LastTransfusionDate.AddDays(21);

            // 5️⃣ Create Entity
            var patient = new ThalassemiaPatient
            {
                DiagnosisDate = request.DiagnosisDate,
                LastTransfusionDate = request.LastTransfusionDate,
                NextTransfusionDate = nextTransfusionDate,
                HospitalId = request.HospitalId,
                UserId = request.UserId
            };

            await unitOfWork.ThalassemiaPatientRepository.AddAsync(patient);

            await unitOfWork.SaveChangesAsync();

            return patient.Id;
        }
    }
}
