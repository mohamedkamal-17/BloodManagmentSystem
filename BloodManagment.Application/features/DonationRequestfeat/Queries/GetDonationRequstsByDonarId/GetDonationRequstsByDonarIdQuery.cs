using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByDonarId
{
    public class GetDonationRequstsByDonarIdQuery : IRequest<ReadOnlyCollection<DonationRequestDto>>
    {
        public int UserId { get; set; }
    }
}
