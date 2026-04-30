using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.DonationRequestfeat.Commandes.RejectDonationRequestCommand
{
    public class RejectDonationRequestCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
