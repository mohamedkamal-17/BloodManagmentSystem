using MediatR;

namespace BloodManagment.Application.features.DonationPredictionService
{

    public class PredictDonationQueryHandler
        : IRequestHandler<PredictDonationQuery, PredictionResultVm>
    {
        private readonly IDonationPredictionService _predictionService;

        public PredictDonationQueryHandler(IDonationPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        public async Task<PredictionResultVm> Handle(
            PredictDonationQuery request,
            CancellationToken cancellationToken)
        {
            // 🧠 Map Query → API DTO
            var apiRequest = new DonationPredictionRequestDto
            {
                RecencyMonths = request.RecencyMonths,
                FrequencyTimes = request.FrequencyTimes,
                MonetaryCc = request.MonetaryCc,
                TimeMonths = request.TimeMonths
            };

            var result = await _predictionService.PredictAsync(apiRequest);

            // 🎯 Map API → VM (Clean boundary)
            return new PredictionResultVm
            {
                Probability = result.Donation_Probability,
                WillDonate = result.Will_Donate,
                Threshold = result.Threshold_Used,

                Stars = result.Gamification.Stars,
                Level = result.Gamification.Level,

                Message = result.Message
            };
        }
    }
}
