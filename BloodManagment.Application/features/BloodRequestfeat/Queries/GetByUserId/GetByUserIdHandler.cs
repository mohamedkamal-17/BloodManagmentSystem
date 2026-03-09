using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByUserId
{
    public class GetByUserIdHandler : IRequestHandler<GetByUserIdQuery, ReadOnlyCollection<BloodRequestDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetByUserIdHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<BloodRequestDto>> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var requstes = await unitOfWorke.BloodRequestRepository.GetByUserIdAsync(request.UserId);
            return mapper.Map<ReadOnlyCollection<BloodRequestDto>>(requstes);
        }
    }
}
