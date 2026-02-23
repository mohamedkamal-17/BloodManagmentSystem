using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByUserId
{
    public class GetDonationRequstsByUserIdSpec : Specefication<DonationRequest>
    {
        public GetDonationRequstsByUserIdSpec(int userId) : base(dr => dr.DonarId == userId)
        {
            Includes.Add(dr => dr.Donar);
        }
    }
}
