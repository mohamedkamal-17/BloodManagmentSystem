using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitById
{
    public class GetBloodUnitByIdQueryHandler
    : IRequestHandler<GetBloodUnitByIdQuery, BloodUnit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBloodUnitByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BloodUnit> Handle(
            GetBloodUnitByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _unitOfWork
                .BloodUnitRepository
                .GetByIdAsync(request.Id);
        }
    }
}
