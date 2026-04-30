using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.ApproveAnemiaRequest
{
    public class ApproveAnemiaRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
