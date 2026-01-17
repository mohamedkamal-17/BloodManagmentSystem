using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByUserId
{
    public class GetAnemiaBloodRequestByUserIdSpc : Specefication<AnemiaBloodRequest>
    {
        public GetAnemiaBloodRequestByUserIdSpc(int userId) : base(rq => rq.PatientId == userId)
        {
        }
    }
}
