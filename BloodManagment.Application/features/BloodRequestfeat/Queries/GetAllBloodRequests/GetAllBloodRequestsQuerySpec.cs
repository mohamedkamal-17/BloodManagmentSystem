using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBloodRequests
{
    public class GetAllBloodRequestsQuerySpec : Specefication<BloodRequest>
    {
        public GetAllBloodRequestsQuerySpec() : base(x => true)
        {
            Includes.Add(x => x.Hospital);
            Includes.Add(x => x.Rescipient);


        }
    }
}
