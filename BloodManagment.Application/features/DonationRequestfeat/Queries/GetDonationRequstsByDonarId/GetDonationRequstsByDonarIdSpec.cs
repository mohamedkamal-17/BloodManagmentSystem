using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByDonarId
{
    public class GetDonationRequstsByDonarIdSpec : Specefication<DonationRequest>
    {
        public GetDonationRequstsByDonarIdSpec(int userId) : base(dr => dr.DonarId == userId)
        {
            Includes.Add(dr => dr.Donar);
        }
    }
}
