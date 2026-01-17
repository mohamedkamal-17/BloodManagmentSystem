using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById
{
    public class GetDonationRequestByIdSpec : Specefication<DonationRequest>
    {
        public GetDonationRequestByIdSpec(int id) : base(dr => dr.Id == id)
        {
            Includes.Add(dr => dr.Donar);

        }
    }
}
