using MediatR;

namespace BloodManagment.Application.features.PasswordResetOtp.Queries.GetByUserId
{
    public class GetByUserIdQuery : IRequest<PasswordResetOtpDto>
    {
        public string UserId { get; set; } = null!;
    }
}
