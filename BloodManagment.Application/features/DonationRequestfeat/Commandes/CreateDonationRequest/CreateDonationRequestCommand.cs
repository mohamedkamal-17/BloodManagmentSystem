using BloodManagment.Application.features.HealthConditionfeat;
using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Commandes.CreateDonationRequest
{
    public class CreateDonationRequestCommand : IRequest<string>
    {
        public string UserId { get; set; }
        public DateTime PreferredDonationDate { get; set; }
        public HealthConditionDto HealthCondition { get; set; }
    }
}
