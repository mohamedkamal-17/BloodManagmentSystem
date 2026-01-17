using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetAllInentory
{
    public class GettAllInentoriesQuery : IRequest<ReadOnlyCollection<GettAllInentoriesDto>>
    {
    }
}
