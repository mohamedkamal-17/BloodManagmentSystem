using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestesByBloodStatus
{
    public class GetBloodRequestesByStatuQueryHandler
        : IRequestHandler<GetBloodRequestesByStatuQuery, ReadOnlyCollection<GetBloodRequestesByStatuDto>>
    {
        private readonly IUnitOfWorke unitOfWorke;
        private readonly Mapper mapper;

        public GetBloodRequestesByStatuQueryHandler(IUnitOfWorke unitOfWorke, Mapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }

        public async Task<ReadOnlyCollection<GetBloodRequestesByStatuDto>> Handle(GetBloodRequestesByStatuQuery request, CancellationToken cancellationToken)
        {

            var bloodRequests = await unitOfWorke.BloodRequestRepository.GetByStatusAsync(request.status);
            return mapper.Map<ReadOnlyCollection<GetBloodRequestesByStatuDto>>(bloodRequests);
        }
    }
}
