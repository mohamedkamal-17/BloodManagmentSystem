using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestDetails
{
    public class GetBloodRequestDetailsQuery : IRequest<BloodRequestDto>
    {
        public int Id { get; set; }

        public GetBloodRequestDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
