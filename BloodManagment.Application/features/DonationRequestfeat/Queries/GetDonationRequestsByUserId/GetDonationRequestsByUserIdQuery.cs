using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestsByUserId
{
    public class GetDonationRequestsByUserIdQuery : IRequest<List<DonationRequestDto>>
    {
        public string UserId { get; set; }
    }
}
