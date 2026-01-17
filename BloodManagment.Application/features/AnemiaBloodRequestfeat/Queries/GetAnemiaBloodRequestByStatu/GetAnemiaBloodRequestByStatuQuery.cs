using BloodManagment.domain.Entities;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByStatu
{
    public class GetAnemiaBloodRequestByStatuQuery : IRequest<ReadOnlyCollection<GetAnemiaBloodRequestByStatuDto>>
    {
        public RequestStatus Status { get; set; }
    }
}
