using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByUserId
{
    public class GetDonationRequstsByUserIdQuery : IRequest<ReadOnlyCollection<DonationRequestDto>>
    {
        public int UserId { get; set; }
    }
}
