using System.Text.Json.Serialization;
namespace BloodManagment.Application.features.DonationPredictionService
{

    public class DonationPredictionRequestDto
    {
        [JsonPropertyName("Recency (months)")]
        public float RecencyMonths { get; set; }

        [JsonPropertyName("Frequency (times)")]
        public float FrequencyTimes { get; set; }

        [JsonPropertyName("Monetary (c.c. blood)")]
        public float MonetaryCc { get; set; }

        [JsonPropertyName("Time (months)")]
        public float TimeMonths { get; set; }
    }
}
