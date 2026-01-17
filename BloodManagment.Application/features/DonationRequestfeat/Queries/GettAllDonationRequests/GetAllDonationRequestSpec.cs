using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests
{
    public class GetAllDonationRequestSpec : Specefication<DonationRequest>
    {
        public GetAllDonationRequestSpec() : base(dr => true)
        {
            Includes.Add(dr => dr.Donar);

        }



    }
}
