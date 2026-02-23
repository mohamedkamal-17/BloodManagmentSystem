using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientsByBloodGroup
{
    public class GetThalassemiaPatientsByBloodGroupQuery
    : IRequest<IList<ThalassemiaPatient>>
    {
        public BloodGroup BloodGroup { get; set; }

        public GetThalassemiaPatientsByBloodGroupQuery(BloodGroup bloodGroup)
        {
            BloodGroup = bloodGroup;
        }
    }
}
