
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByPatientId
{
    public class GetAnemiaBloodRequestByPatientIdQuery : IRequest<ReadOnlyCollection<GetAnemiaBloodRequestByPatientIdDto>>
    {
        public int UserId { get; set; }
    }
}
