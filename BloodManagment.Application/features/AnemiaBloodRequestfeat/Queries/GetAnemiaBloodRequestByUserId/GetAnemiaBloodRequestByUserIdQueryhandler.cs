using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByUserId
{
    public class GetAnemiaBloodRequestByUserIdQueryhandler : IRequestHandler<GetAnemiaBloodRequestByUserIdQuery, ReadOnlyCollection<GetAnemiaBloodRequestByUserIdDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetAnemiaBloodRequestByUserIdQueryhandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<GetAnemiaBloodRequestByUserIdDto>> Handle(GetAnemiaBloodRequestByUserIdQuery request, CancellationToken cancellationToken)
        {
            var AnemiaBloodRequests = await unitOfWorke.AnemiaBloodRequestRepository.GetByUserIdAsync(request.UserId);
            return mapper.Map<ReadOnlyCollection<GetAnemiaBloodRequestByUserIdDto>>(AnemiaBloodRequests);
        }
    }
}
