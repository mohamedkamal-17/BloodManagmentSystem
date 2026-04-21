namespace BloodManagment.Application.features.DonationPredictionService
{
    using System.Net.Http.Json;

    public class DonationPredictionService : IDonationPredictionService
    {
        private readonly HttpClient _httpClient;

        public DonationPredictionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PredictionResponseDto> PredictAsync(DonationPredictionRequestDto request)
        {
            var response = await _httpClient.PostAsJsonAsync("/predict", request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Prediction API failed");
            }

            var result = await response.Content.ReadFromJsonAsync<PredictionResponseDto>();

            return result!;
        }
    }
}
