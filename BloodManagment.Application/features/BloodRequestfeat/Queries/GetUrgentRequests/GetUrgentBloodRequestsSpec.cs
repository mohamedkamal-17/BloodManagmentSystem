using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetUrgentRequests
{
    public class GetUrgentBloodRequestsSpec : Specefication<BloodRequest>
    {
        public GetUrgentBloodRequestsSpec() : base(r => r.IsEmergency == true)
        {


        }
    }
}
