using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BloodManagment.Application.features.Auth.Commandes.ResetPasswordWithOtp
{
    public class ResetPasswordWithOtpCommandHandler
    : IRequestHandler<ResetPasswordWithOtpCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOtpService _otpService;
        private readonly IUnitOfWork _unitOfWorke;

        public ResetPasswordWithOtpCommandHandler(
            UserManager<ApplicationUser> userManager,
            IOtpService otpService,
            IUnitOfWork unitOfWorke)
        {
            _userManager = userManager;
            _otpService = otpService;
            _unitOfWorke = unitOfWorke;
        }

        public async Task Handle(
            ResetPasswordWithOtpCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new ApplicationException("Invalid request");

            var otpEntity = await _unitOfWorke.PasswordResetOtpRepository.GetByUserIdAsync(user.Id);


            if (otpEntity == null ||
                !_otpService.Verify(request.Otp, otpEntity.OtpHash))
                throw new ApplicationException("Invalid or expired OTP");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(
                user,
                token,
                request.NewPassword);

            if (!result.Succeeded)
                throw new ApplicationException(
                    string.Join(", ", result.Errors.Select(e => e.Description)));

            otpEntity.IsUsed = true;
            await _unitOfWorke.SaveChangesAsync();
        }
    }

}
