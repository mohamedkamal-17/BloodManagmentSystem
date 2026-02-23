using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NETCore.MailKit.Core;

namespace BloodManagment.Application.features.Auth.Commandes.PasswordReset
{
    public class RequestPasswordResetOtpCommandHandler
     : IRequestHandler<RequestPasswordResetOtpCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOtpService _otpService;
        private readonly IUnitOfWork _unitOfWorke;
        private readonly IEmailService _emailService;



        public RequestPasswordResetOtpCommandHandler(
            UserManager<ApplicationUser> userManager,
            IOtpService otpService,
            IUnitOfWork unitOfWorke,
            IEmailService emailService)
        {
            _userManager = userManager;
            _otpService = otpService;
            _unitOfWorke = unitOfWorke;
            _emailService = emailService;
        }

        public async Task Handle(
            RequestPasswordResetOtpCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return; // 🔐 security

            var otp = _otpService.GenerateOtp();

            var entity = new domain.Entities.PasswordResetOtp
            {
                UserId = user.Id,
                OtpHash = _otpService.HashOtp(otp),
                ExpireAt = DateTime.UtcNow.AddMinutes(5),
                IsUsed = false
            };

            await _unitOfWorke.PasswordResetOtpRepository.AddAsync(entity);
            await _unitOfWorke.SaveChangesAsync();

            await _emailService.SendAsync(
                user.Email!,
                "Your password reset OTP",
                $"Your OTP is: {otp} (valid for 5 minutes)");
        }
    }

}
