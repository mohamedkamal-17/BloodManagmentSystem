using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests
{
    public class GetAllDonationRequestQuery : IRequest<List<DonationRequestDto>>
    {
    }
}
