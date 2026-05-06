using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

   
    using MediatR;
namespace BloodManagment.Application.features.Donarfeat.Queries.GetDonarProfile
{

    public class GetDonarProfileQuery : IRequest<DonarVm>
    {
        public int Id { get; set; }

       
    }
}
