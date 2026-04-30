using MediatR;

namespace BloodManagment.Application.features.Auth.Commandes.PasswordReset
{
    public class RequestPasswordResetOtpCommand : IRequest<bool>
    {
        public String Email { get; set; } = null!;

    }
}

