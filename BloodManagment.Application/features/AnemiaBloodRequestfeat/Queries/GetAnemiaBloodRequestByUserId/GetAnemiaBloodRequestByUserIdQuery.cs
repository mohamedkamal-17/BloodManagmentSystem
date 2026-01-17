
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByUserId
{
    public class GetAnemiaBloodRequestByUserIdQuery : IRequest<ReadOnlyCollection<GetAnemiaBloodRequestByUserIdDto>>
    {
        public int UserId { get; set; }
    }
}
