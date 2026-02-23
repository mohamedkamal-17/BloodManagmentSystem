using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetAllThalassemiaPatients
{
    public class GetAllThalassemiaPatientsHandler
    : IRequestHandler<GetAllThalassemiaPatientsQuery, IList<ThalassemiaPatient>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllThalassemiaPatientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<ThalassemiaPatient>> Handle(
            GetAllThalassemiaPatientsQuery request,
            CancellationToken cancellationToken)
        {
            return await _unitOfWork
                .ThalassemiaPatientRepository
                .GetAllAsync();
        }
    }
}
