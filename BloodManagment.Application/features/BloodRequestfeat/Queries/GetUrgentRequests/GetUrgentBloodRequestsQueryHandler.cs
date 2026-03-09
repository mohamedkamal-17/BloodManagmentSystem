using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetUrgentRequests
{
    public class GetUrgentBloodRequestsQueryHandler : IRequestHandler<GetUrgentBloodRequestsQuery, List<BloodRequestDto>>
    {
        public Task<List<BloodRequestDto>> Handle(GetUrgentBloodRequestsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
