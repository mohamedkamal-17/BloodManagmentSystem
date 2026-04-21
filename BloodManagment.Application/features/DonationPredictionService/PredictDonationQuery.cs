using MediatR;

namespace BloodManagment.Application.features.DonationPredictionService
{

    public class PredictDonationQuery : IRequest<PredictionResultVm>
    {
        public float RecencyMonths { get; set; }
        public float FrequencyTimes { get; set; }
        public float MonetaryCc { get; set; }
        public float TimeMonths { get; set; }
    }
}
