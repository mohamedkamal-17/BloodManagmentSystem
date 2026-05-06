using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByUserId
{
    public class GetAnemiaBloodRequestByUserIdQuery : IRequest<List<GetAnemiaBloodRequestByUserIdDto>>
    {
        public string UserId { get; set; }
    }
}
