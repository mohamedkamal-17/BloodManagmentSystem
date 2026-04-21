namespace BloodManagment.Application.features.DonationPredictionService
{
    public interface IDonationPredictionService
    {
        Task<PredictionResponseDto> PredictAsync(DonationPredictionRequestDto request);
    }
}
