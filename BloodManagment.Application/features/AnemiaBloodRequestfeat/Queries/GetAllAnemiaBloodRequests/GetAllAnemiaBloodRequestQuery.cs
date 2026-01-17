using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAllAnemiaBloodRequests
{
    public class GetAllAnemiaBloodRequestQuery : IRequest<ReadOnlyCollection<GetAllAnemiaBloodRequestDto>>
    {

    }
}
