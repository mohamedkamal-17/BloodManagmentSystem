using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestsByUserIdQuery
{
    public class GetBloodRequestsByUserIdQuery : IRequest<List<BloodRequestDto>>
    {
        public string UserId { get; set; }
    }
}
