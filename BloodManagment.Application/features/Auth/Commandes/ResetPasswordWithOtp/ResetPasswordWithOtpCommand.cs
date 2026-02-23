using MediatR;

namespace BloodManagment.Application.features.Auth.Commandes.ResetPasswordWithOtp
{
    public class ResetPasswordWithOtpCommand : IRequest
    {
        public string Email { get; set; }
        public string Otp { get; set; }
        public string NewPassword { get; set; }
    }
}
