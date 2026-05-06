using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.CheckThalassemiaPatientExistByUserId
{
    public class CheckThalassemiaPatientExistByUserIdQuery : IRequest<bool>
    {
        public string UserId { get; set; }
    }
}
