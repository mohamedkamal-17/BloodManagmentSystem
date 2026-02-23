using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientsByBloodGroup
{
    public class GetThalassemiaPatientsByBloodGroupHandler
    : IRequestHandler<GetThalassemiaPatientsByBloodGroupQuery, IList<ThalassemiaPatient>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetThalassemiaPatientsByBloodGroupHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<ThalassemiaPatient>> Handle(
            GetThalassemiaPatientsByBloodGroupQuery request,
            CancellationToken cancellationToken)
        {
            var pationts = await unitOfWork.ThalassemiaPatientRepository.GetByBloodGroupAsync(request.BloodGroup);

            return pationts;
        }
    }
}
