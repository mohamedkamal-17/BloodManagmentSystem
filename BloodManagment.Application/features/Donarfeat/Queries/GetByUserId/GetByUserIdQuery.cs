using MediatR;

namespace BloodManagment.Application.features.Donarfeat.Queries.GetByUserId
{
    public class GetByUserIdQuery : IRequest<DonarDto>
    {
        public string UserId { get; set; } = null!;
    }
}
