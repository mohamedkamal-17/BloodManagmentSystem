using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientByUserId
{
    public class GetThalassemiaPatientByUserIdQueryHandler
     : IRequestHandler<GetThalassemiaPatientByUserIdQuery, ThalassemiaPatientDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetThalassemiaPatientByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ThalassemiaPatientDto> Handle(
            GetThalassemiaPatientByUserIdQuery request,
            CancellationToken cancellationToken)
        {
            var patients = await _unitOfWork
                .ThalassemiaPatientRepository
                .GetByUserIdAsync(request.UserId);

            var patient = patients.FirstOrDefault();

            if (patient == null)
                throw new NotFoundException("Patient profile not found");

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
