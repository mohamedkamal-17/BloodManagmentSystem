using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestesByBloodStatus
{
    public class GetBloodRequestesByStatuQueryHandler
        : IRequestHandler<GetBloodRequestesByStatuQuery, ReadOnlyCollection<BloodRequestDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetBloodRequestesByStatuQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }

        public async Task<ReadOnlyCollection<BloodRequestDto>> Handle(GetBloodRequestesByStatuQuery request, CancellationToken cancellationToken)
        {

            var bloodRequests = await unitOfWorke.BloodRequestRepository.GetByStatusAsync(request.status);
            return mapper.Map<ReadOnlyCollection<BloodRequestDto>>(bloodRequests);
        }
    }
}
