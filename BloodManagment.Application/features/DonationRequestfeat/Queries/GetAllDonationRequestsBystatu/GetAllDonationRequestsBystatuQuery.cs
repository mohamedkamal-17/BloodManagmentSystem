using BloodManagment.domain.Entities;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu
{
    public class GetAllDonationRequestsBystatuQuery : IRequest<ReadOnlyCollection<GetAllDonationRequestsBystatuDto>>
    {
        public RequestStatus Statu { get; set; }
    }
}
