using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientsByBloodGroup
{
    public class GetThalassemiaPatientsByBloodGroupSpec
     : Specefication<ThalassemiaPatient>
    {
        public GetThalassemiaPatientsByBloodGroupSpec(BloodGroup bloodGroup)
            : base(p => p.BloodGroup == bloodGroup)
        {
            Includes.Add(p => p.User);
            Includes.Add(p => p.Hospital);
        }
    }
}
