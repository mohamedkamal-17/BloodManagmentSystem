using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetAllThalassemiaPatients
{
    public class GetAllThalassemiaPatientsSpec
    : Specefication<ThalassemiaPatient>
    {
        public GetAllThalassemiaPatientsSpec()
            : base(p => true)
        {
            Includes.Add(p => p.Hospital);
            Includes.Add(p => p.User);
        }
    }
}
