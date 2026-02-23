using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientById
{
    public class GetThalassemiaPatientByIdSpec
    : Specefication<ThalassemiaPatient>
    {
        public GetThalassemiaPatientByIdSpec(int id)
            : base(p => p.Id == id)
        {
            Includes.Add(p => p.Hospital);
            Includes.Add(p => p.User);
            Includes.Add(p => p.thalassemiaPatientDonorAssignements);
        }
    }
}
