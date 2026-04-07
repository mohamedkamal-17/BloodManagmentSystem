using AutoMapper;
using BloodManagment.Application.Commane;

using MediatR;


namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetBloodInventoryById
{
    class GetBloodInventoryByIdQueryHandler : IRequestHandler<GetBloodInventoryByIdQuery, BloodInentoriesDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public GetBloodInventoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        public async Task<BloodInentoriesDto> Handle(
            GetBloodInventoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork
                .BloodInventoryRepository
            .GetByIdAsync(request.Id);

            return mapper.Map<BloodInentoriesDto>(inventory);
        }
    }
}
