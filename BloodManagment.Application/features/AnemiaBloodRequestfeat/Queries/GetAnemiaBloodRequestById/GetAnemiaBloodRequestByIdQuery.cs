using BloodManagment.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestById
{
    public record GetAnemiaBloodRequestByIdQuery(int Id)
     : IRequest<AnemiaBloodRequest>;
}
