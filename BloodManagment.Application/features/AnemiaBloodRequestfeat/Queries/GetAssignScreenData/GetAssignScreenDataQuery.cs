using MediatR;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAssignScreenData
{
    public class GetAssignScreenDataQuery : IRequest<AssignScreenVm>
    {
        public int RequestId { get; set; }
    }
}
