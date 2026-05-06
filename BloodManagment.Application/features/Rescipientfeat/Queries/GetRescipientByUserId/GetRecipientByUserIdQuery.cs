using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Rescipientfeat.Queries.GetRescipientByUserId
{
    public class GetRecipientByUserIdQuery:IRequest<RecipientDto>
    {
        public string UserId { get; set; }

        public GetRecipientByUserIdQuery(string userId)
        {
            UserId = userId;
        }

    }
}
