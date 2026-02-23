namespace BloodManagment.Application.Commane
{
    public interface IOtpService
    {
        string GenerateOtp();
        string HashOtp(string otp);
        bool Verify(string otp, string hash);
    }

}
