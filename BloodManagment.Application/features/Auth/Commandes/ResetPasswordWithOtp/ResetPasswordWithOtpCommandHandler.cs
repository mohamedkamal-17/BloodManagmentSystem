using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace BloodManagment.Application.features.Auth.Commandes.ResetPasswordWithOtp
{
    public class ResetPasswordWithOtpCommandHandler
    : IRequestHandler<ResetPasswordWithOtpCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOtpService _otpService;
        private readonly IUnitOfWork _unitOfWorke;
        private readonly IMemoryCache memoryCache;

        public ResetPasswordWithOtpCommandHandler(
            UserManager<ApplicationUser> userManager,
            IOtpService otpService,
            IUnitOfWork unitOfWorke,
            IMemoryCache memoryCache)
        {
            _userManager = userManager;
            _otpService = otpService;
            _unitOfWorke = unitOfWorke;
            this.memoryCache = memoryCache;
        }

        public async Task Handle(
            ResetPasswordWithOtpCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new ApplicationException("Invalid request");
            //var cacheKey = $"otp_{user.Id}";

            //if (!memoryCache.TryGetValue(cacheKey, out OtpCacheModel otpData))
            //    throw new ApplicationException("OTP expired or not found");

            //// ⏱️ تحقق من expiration
            //if (otpData.ExpireAt < DateTime.UtcNow)
            //{
            //    memoryCache.Remove(cacheKey);
            //    throw new ApplicationException("OTP expired");
            //}

            //// 🔐 تحقق من الكود
            //if (!_otpService.Verify(request.Otp, otpData.OtpHash))
            //{
            //    otpData.Attempts++;

            //    if (otpData.Attempts >= 5)
            //    {
            //        memoryCache.Remove(cacheKey);
            //        throw new ApplicationException("Too many attempts");
            //    }

            //    // مهم: رجّع التعديل في الكاش
            //    memoryCache.Set(cacheKey, otpData, TimeSpan.FromMinutes(5));

            //    throw new ApplicationException("Invalid OTP");
            //}




            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(
                user,
                token,
                request.NewPassword);

            if (!result.Succeeded)
                throw new ApplicationException(
                    string.Join(", ", result.Errors.Select(e => e.Description)));

            //memoryCache.Remove(cacheKey);

        }
    }

}
