using AutoMapper;
using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetAvailableBloodUnits
{
    public class GetAvailableBloodUnitsQueryHandler
    : IRequestHandler<GetAvailableBloodUnitsQuery, IReadOnlyList<BloodUnit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GetAvailableBloodUnitsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<BloodUnit>> Handle(
            GetAvailableBloodUnitsQuery request,
            CancellationToken cancellationToken)
        {

            var allUnits = await _unitOfWork.BloodUnitRepository.GetAllAsync();
            return mapper.Map<IReadOnlyList<BloodUnit>, IReadOnlyList<BloodUnit>>(
                allUnits);
        }
    }
}
