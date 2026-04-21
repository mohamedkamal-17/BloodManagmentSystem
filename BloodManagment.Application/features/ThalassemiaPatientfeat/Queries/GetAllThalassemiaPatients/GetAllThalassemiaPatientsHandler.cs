using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetAllThalassemiaPatients
{
    public class GetAllThalassemiaPatientsHandler
      : IRequestHandler<GetAllThalassemiaPatientsQuery, IList<ThalassemiaPatientDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllThalassemiaPatientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<ThalassemiaPatientDto>> Handle(
            GetAllThalassemiaPatientsQuery request,
            CancellationToken cancellationToken)
        {
            var patients = await _unitOfWork
                .ThalassemiaPatientRepository
                .GetAllAsync();

            return patients.Select(p => new ThalassemiaPatientDto
            {
                Id = p.Id,
                DiagnosisDate = p.DiagnosisDate,
                LastTransfusionDate = p.LastTransfusionDate,
                NextTransfusionDate = p.NextTransfusionDate,
                BloodGroup = p.BloodGroup,

                HospitalId = p.HospitalId,
                HospitalName = p.Hospital != null ? p.Hospital.Name : "—",

                //  FullName = p.FullName
            }).ToList();
        }
    }
}

