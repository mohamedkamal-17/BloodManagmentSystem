using BloodManagment.Application.features.HealthConditionfeat;
using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Commandes.CreateDonationRequest
{
    public class CreateDonationRequestCommand : IRequest<int>
    {
        public DateTime PreferredDonationDate { get; set; }
        public HealthConditionDto HealthCondition { get; set; }
    }
}
