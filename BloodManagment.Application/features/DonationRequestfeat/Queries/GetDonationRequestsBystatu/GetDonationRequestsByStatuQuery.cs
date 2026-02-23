using BloodManagment.domain.Entities;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu
{
    public class GetDonationRequestsByStatuQuery : IRequest<ReadOnlyCollection<GetDonationRequestsByStatuDto>>
    {
        public RequestStatus Statu { get; set; }
    }
}
