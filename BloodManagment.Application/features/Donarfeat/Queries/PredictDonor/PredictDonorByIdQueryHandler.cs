using BloodManagment.Application.Commane;
using BloodManagment.Application.features.DonationPredictionService;
using MediatR;

namespace BloodManagment.Application.features.Donarfeat.Queries.PredictDonor
{
    public class PredictDonorByIdQueryHandler
     : IRequestHandler<PredictDonorByIdQuery, PredictionResultVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationPredictionService _predictionService;

        public PredictDonorByIdQueryHandler(
            IUnitOfWork unitOfWork,
            IDonationPredictionService predictionService)
        {
            _unitOfWork = unitOfWork;
            _predictionService = predictionService;
        }

        public async Task<PredictionResultVm> Handle(
            PredictDonorByIdQuery request,
            CancellationToken cancellationToken)
        {
            var donor = await _unitOfWork.DonarRepository.GetByIdAsync(request.DonorId);

            if (donor == null)
                throw new Exception("Donor not found");

            // 🧠 Feature Engineering
            var recency = donor.LastDonationDate.HasValue
                ? (float)(DateTime.UtcNow - donor.LastDonationDate.Value).TotalDays / 30
                : 24; // default

            var frequency = donor.DonationCount;

            var monetary = donor.DonationCount * 250; // cc

            var time = donor.DonationCount * 3; // estimation

            var apiRequest = new DonationPredictionRequestDto
            {
                RecencyMonths = recency,
                FrequencyTimes = frequency,
                MonetaryCc = monetary,
                TimeMonths = time
            };

            var result = await _predictionService.PredictAsync(apiRequest);

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
