namespace BloodManagment.Application.features.DonationPredictionService
{
    public class PredictionResponseDto
    {
        public float Donation_Probability { get; set; }
        public bool Will_Donate { get; set; }
        public float Threshold_Used { get; set; }

        public GamificationDto Gamification { get; set; }

        public string Message { get; set; }
    }

    public class GamificationDto
    {
        public int Stars { get; set; }
        public string Level { get; set; }
    }
}
