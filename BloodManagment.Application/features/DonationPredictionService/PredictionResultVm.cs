namespace BloodManagment.Application.features.DonationPredictionService
{
    public class PredictionResultVm
    {
        public float Probability { get; set; }
        public bool WillDonate { get; set; }
        public float Threshold { get; set; }

        public int Stars { get; set; }
        public string Level { get; set; }

        public string Message { get; set; }
    }
}
