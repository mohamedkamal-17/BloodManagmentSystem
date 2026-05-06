using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByPatientId
{
    public class GetAnemiaBloodRequestByPatientIdSpc : Specefication<AnemiaBloodRequest>
    {
        public GetAnemiaBloodRequestByPatientIdSpc(int userId) : base(rq => rq.PatientId == userId)
        {
        }
    }
}
