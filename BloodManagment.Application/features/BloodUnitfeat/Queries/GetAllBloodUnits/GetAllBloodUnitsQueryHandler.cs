using AutoMapper;
using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodUnitfeat.Queries.GetAllBloodUnits
{
    public class GetAllBloodUnitsQueryHandler
     : IRequestHandler<GetAllBloodUnitsQuery, IReadOnlyList<BloodUnitDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GetAllBloodUnitsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }



        async Task<IReadOnlyList<BloodUnitDTO>> IRequestHandler<GetAllBloodUnitsQuery, IReadOnlyList<BloodUnitDTO>>.Handle(GetAllBloodUnitsQuery request, CancellationToken cancellationToken)
        {
            var bloodUnits = await _unitOfWork.BloodUnitRepository.GetAllAsync();

            return mapper.Map<IReadOnlyList<BloodUnit>, IReadOnlyList<BloodUnitDTO>>(bloodUnits);

        }
    }
}
