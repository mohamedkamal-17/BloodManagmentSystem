using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu
{
    public class GetAllDonationRequestsBystatuSpec : Specefication<DonationRequest>
    {
        public GetAllDonationRequestsBystatuSpec(RequestStatus statu) : base(dr => dr.Statu == statu)
        {
            Includes.Add(dr => dr.Donar);

        }
    }
}
