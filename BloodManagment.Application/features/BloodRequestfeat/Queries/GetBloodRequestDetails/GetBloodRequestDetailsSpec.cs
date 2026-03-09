using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestDetails
{
    public class GetBloodRequestDetailsSpec : Specefication<BloodRequest>
    {
        public GetBloodRequestDetailsSpec(int id) : base(x => x.Id == id)
        {
            Includes.Add(x => x.Rescipient);
            Includes.Add(x => x.Hospital);
        }
    }
}
