namespace BloodManagment.Application.features.PasswordResetOtp.Queries.GetByUserId
{
    public class PasswordResetOtpDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string OtpHash { get; set; } = null!;
        public DateTime ExpireAt { get; set; }
        public bool IsUsed { get; set; }

    }
}
