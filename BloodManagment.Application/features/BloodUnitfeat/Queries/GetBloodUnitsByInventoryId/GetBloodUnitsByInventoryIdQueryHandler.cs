using AutoMapper;
using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByInventoryId
{
    public class GetBloodUnitsByInventoryIdQueryHandler
     : IRequestHandler<GetBloodUnitsByInventoryIdQuery, IReadOnlyList<BloodUnitDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GetBloodUnitsByInventoryIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<BloodUnit>> Handle(
            GetBloodUnitsByInventoryIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _unitOfWork
                .BloodUnitRepository
                .GetByInventoryIdAsync(request.InventoryId);
        }

        async Task<IReadOnlyList<BloodUnitDTO>> IRequestHandler<GetBloodUnitsByInventoryIdQuery, IReadOnlyList<BloodUnitDTO>>.Handle(GetBloodUnitsByInventoryIdQuery request, CancellationToken cancellationToken)
        {
            var bloodUnits = await _unitOfWork
                .BloodUnitRepository
                .GetByInventoryIdAsync(request.InventoryId);
            return mapper.Map<IReadOnlyList<BloodUnit>, IReadOnlyList<BloodUnitDTO>>(bloodUnits);
        }
    }
}
