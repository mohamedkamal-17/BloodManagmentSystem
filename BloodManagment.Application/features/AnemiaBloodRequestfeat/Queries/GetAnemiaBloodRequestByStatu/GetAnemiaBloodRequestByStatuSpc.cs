using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByStatu
{
    public class GetAnemiaBloodRequestByStatuSpc : Specefication<AnemiaBloodRequest>
    {
        public GetAnemiaBloodRequestByStatuSpc(RequestStatus status) : base(a => a.Status == status)
        {

        }
    }
}
