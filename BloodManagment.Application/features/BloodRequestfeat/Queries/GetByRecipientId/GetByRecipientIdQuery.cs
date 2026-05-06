using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByRecipientId
{
    public class GetByRecipientIdQuery : IRequest<ReadOnlyCollection<BloodRequestDto>>
    {
        public int UserId { get; set; }
    }
}
