using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu
{
    public class GetDonationRequestsBystatuSpec : Specefication<DonationRequest>
    {
        public GetDonationRequestsBystatuSpec(RequestStatus statu) : base(dr => dr.Statu == statu)
        {
            Includes.Add(dr => dr.Donar);

        }
    }
}
