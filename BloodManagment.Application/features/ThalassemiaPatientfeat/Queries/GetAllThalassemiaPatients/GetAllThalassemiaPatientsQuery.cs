using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetAllThalassemiaPatients
{
    public class GetAllThalassemiaPatientsQuery
    : IRequest<IList<ThalassemiaPatientDto>>
    {
    }
}
