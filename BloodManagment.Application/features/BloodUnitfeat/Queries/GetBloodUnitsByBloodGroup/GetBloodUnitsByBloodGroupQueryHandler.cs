using AutoMapper;
using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByBloodGroup
{
    public class GetBloodUnitsByBloodGroupQueryHandler
    : IRequestHandler<GetBloodUnitsByBloodGroupQuery, IReadOnlyList<BloodUnitDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GetBloodUnitsByBloodGroupQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }



        async Task<IReadOnlyList<BloodUnitDTO>> IRequestHandler<GetBloodUnitsByBloodGroupQuery, IReadOnlyList<BloodUnitDTO>>.Handle(GetBloodUnitsByBloodGroupQuery request, CancellationToken cancellationToken)
        {
            var bloodUnits = await _unitOfWork.BloodUnitRepository.GetByBloodGroupAsync(request.BloodGroup);

            return mapper.Map<IReadOnlyList<BloodUnit>, IReadOnlyList<BloodUnitDTO>>(bloodUnits);
        }
    }
}
