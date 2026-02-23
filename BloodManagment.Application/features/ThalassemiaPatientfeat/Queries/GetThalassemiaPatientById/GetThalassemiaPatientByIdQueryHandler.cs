using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientByIdQuery
{

    public class GetThalassemiaPatientByIdQueryHandler
        : IRequestHandler<GetThalassemiaPatientByIdQuery, ThalassemiaPatientDto>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetThalassemiaPatientByIdQueryHandler(IUnitOfWork
            unitOfWork)
        {

            this.unitOfWork = unitOfWork;
        }

        public async Task<ThalassemiaPatientDto> Handle(
            GetThalassemiaPatientByIdQuery request,
            CancellationToken cancellationToken)
        {
            // 🔥 Direct call to IThalassemiaPatientRepository
            var patient = await unitOfWork
                .ThalassemiaPatientRepository
                .GetByIdAsync(request.Id);

            if (patient == null)
                throw new NotFoundException("Thalassemia Patient not found");

            // Mapping (manual mapping example)
            return new ThalassemiaPatientDto
            {
                Id = patient.Id,
                DiagnosisDate = patient.DiagnosisDate,
                LastTransfusionDate = patient.LastTransfusionDate,
                NextTransfusionDate = patient.NextTransfusionDate,
                HospitalName = patient.Hospital?.Name ?? "",
                UserFullName = patient.User?.FullName ?? ""
            };
        }
    }
}
