using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetUrgentRequests
{
    public class GetUrgentBloodRequestsQueryHandler : IRequestHandler<GetUrgentBloodRequestsQuery, List<UrgentBloodRequestsDto>>
    {
        public Task<List<UrgentBloodRequestsDto>> Handle(GetUrgentBloodRequestsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
