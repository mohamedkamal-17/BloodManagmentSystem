using MediatR;

namespace BloodManagment.Application.features.Donarfeat.Queries.GetAllDonors
{
    public class GetAllDonorsQuery : IRequest<List<DonarVm>>
    {
    }
}
