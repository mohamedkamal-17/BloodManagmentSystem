using BloodManagment.domain.Entities;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestesByBloodStatus
{
    public class GetBloodRequestesByStatuQuery : IRequest<ReadOnlyCollection<BloodRequestDto>>
    {
        public RequestStatus status { get; set; }
    }
}
