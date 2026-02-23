using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientByUserId
{
    public class GetThalassemiaPatientsByUserIdSpec
    : Specefication<ThalassemiaPatient>
    {
        public GetThalassemiaPatientsByUserIdSpec(string userId)
            : base(p => p.UserId == userId)
        {
            Includes.Add(p => p.User);
            Includes.Add(p => p.Hospital);
        }
    }
}
