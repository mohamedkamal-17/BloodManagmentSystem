using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetUrgentRequests
{
    public class GetUrgentBloodRequestsQuery : IRequest<List<UrgentBloodRequestsDto>>
    {
    }
}
