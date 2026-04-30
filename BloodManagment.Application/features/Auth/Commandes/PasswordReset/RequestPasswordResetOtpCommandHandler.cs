using BloodManagment.Application.Commane;
using BloodManagment.Application.features.Auth.Commandes.ResetPasswordWithOtp;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;


namespace BloodManagment.Application.features.Auth.Commandes.PasswordReset
{
    public class RequestPasswordResetOtpCommandHandler
     : IRequestHandler<RequestPasswordResetOtpCommand,bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOtpService _otpService;
        private readonly IUnitOfWork _unitOfWorke;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache memoryCache;

        public RequestPasswordResetOtpCommandHandler(
            UserManager<ApplicationUser> userManager,
            IOtpService otpService,
            IUnitOfWork unitOfWorke,
            IEmailService emailService,
            IMemoryCache memoryCache)
        {
            _userManager = userManager;
            _otpService = otpService;
            _unitOfWorke = unitOfWorke;
            _emailService = emailService;
            this.memoryCache = memoryCache;
        }

        public async Task<bool> Handle(
            RequestPasswordResetOtpCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return false; // 🔐 security

            var otp = _otpService.GenerateOtp();

            var cacheKey = $"otp_{user.Id}";

            var cacheValue = new OtpCacheModel
            {
                OtpHash = _otpService.HashOtp(otp),
                ExpireAt = DateTime.UtcNow.AddMinutes(5),

            };

            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            memoryCache.Set(cacheKey, cacheValue, options);

            await _emailService.SendAsync(
                    user.Email!,
                    "Reset Password OTP",
                    $"Your OTP is: {otp}"
                );
            return true;
        }
    }

}
