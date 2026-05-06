using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Rescipientfeat.Queries.GetRescipientById
{
    public class GetRecipientByIdQuery : IRequest<RecipientDto>
    {
        public int Id { get; set; }

        public GetRecipientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
