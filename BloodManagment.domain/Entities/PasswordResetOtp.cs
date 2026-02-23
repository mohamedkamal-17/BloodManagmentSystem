namespace BloodManagment.domain.Entities
{
    public class PasswordResetOtp
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string OtpHash { get; set; } = null!;
        public DateTime ExpireAt { get; set; }
        public bool IsUsed { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }

}
