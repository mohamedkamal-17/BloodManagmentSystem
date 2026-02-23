using BloodManagment.Application.Commane;
using System.Security.Cryptography;
using System.Text;

namespace BloodManagment.Infrastructure.Comman
{
    public class OtpService : IOtpService
    {
        public string GenerateOtp()
            => RandomNumberGenerator.GetInt32(100000, 999999).ToString();

        public string HashOtp(string otp)
            => Convert.ToBase64String(
                SHA256.HashData(Encoding.UTF8.GetBytes(otp)));

        public bool Verify(string otp, string hash)
            => HashOtp(otp) == hash;
    }

}
