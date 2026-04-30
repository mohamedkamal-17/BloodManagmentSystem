using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Rescipientfeat.Queries.GetAllRecipients
{
    public class GetAllRecipientsQuery
     : IRequest<IList<RecipientDto>>
    {
    }
}
