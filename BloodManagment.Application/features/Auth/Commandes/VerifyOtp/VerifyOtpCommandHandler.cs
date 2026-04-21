using BloodManagment.Application.Commane;
using BloodManagment.Application.features.Auth.Commandes.ResetPasswordWithOtp;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace BloodManagment.Application.features.Auth.Commandes.VerifyOtp
{

    public class VerifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOtpService _otpService;
        private readonly IMemoryCache _memoryCache;

        public VerifyOtpCommandHandler(
            UserManager<ApplicationUser> userManager,
            IOtpService otpService,
            IMemoryCache memoryCache)
        {
            _userManager = userManager;
            _otpService = otpService;
            _memoryCache = memoryCache;
        }

        public async Task<bool> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {
            // 🔎 Find user
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new ApplicationException("Invalid request");

            var cacheKey = $"otp_{user.Id}";

            // 📦 Get OTP from cache
            if (!_memoryCache.TryGetValue(cacheKey, out OtpCacheModel otpData))
                throw new ApplicationException("OTP expired or not found");

            // ⏱️ Expiration check
            if (otpData.ExpireAt < DateTime.UtcNow)
            {
                _memoryCache.Remove(cacheKey);
                throw new ApplicationException("OTP expired");
            }

            // 🔐 Verify OTP
            if (!_otpService.Verify(request.Otp, otpData.OtpHash))
            {
                otpData.Attempts++;

                if (otpData.Attempts >= 5)
                {
                    _memoryCache.Remove(cacheKey);
                    throw new ApplicationException("Too many attempts");
                }

                // 🔁 update cache with incremented attempts
                _memoryCache.Set(cacheKey, otpData, TimeSpan.FromMinutes(5));

                throw new ApplicationException("Invalid OTP");
            }

            // ✅ Success → remove OTP
            _memoryCache.Remove(cacheKey);

            return true;
        }
    }
}
