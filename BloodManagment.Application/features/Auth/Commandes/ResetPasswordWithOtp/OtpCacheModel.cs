namespace BloodManagment.Application.features.Auth.Commandes.ResetPasswordWithOtp
{
    internal class OtpCacheModel
    {
        public string OtpHash { get; set; }
        public DateTime ExpireAt { get; set; }
        public int Attempts { get; set; } = 0;
    }
}