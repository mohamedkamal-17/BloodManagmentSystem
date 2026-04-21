using MediatR;

namespace BloodManagment.Application.features.Auth.Commandes.VerifyOtp
{
    public class VerifyOtpCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
