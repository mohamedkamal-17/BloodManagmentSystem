using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests
{
    public class GetAllDonationRequestQuery : IRequest<ReadOnlyCollection<GetAllDonationRequestDto>>
    {
    }
}
