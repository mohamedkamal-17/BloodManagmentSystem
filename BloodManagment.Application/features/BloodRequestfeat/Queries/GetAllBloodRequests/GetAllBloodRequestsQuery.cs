using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBloodRequests
{
    public class GetAllBloodRequestsQuery : IRequest<ReadOnlyCollection<GetAllBloodRequestsDto>>
    {
    }
}
