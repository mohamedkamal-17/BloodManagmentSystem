using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByUserId
{
    public class GetByUserIdQuery : IRequest<ReadOnlyCollection<GetByUserIdDTO>>
    {
        public int UserId { get; set; }
    }
}
