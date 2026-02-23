using BloodManagment.Application.features.Auth.Commandes.ApiLogin;
using BloodManagment.Application.features.Auth.Commandes.LoginUser;
using BloodManagment.Application.features.Auth.Commandes.PasswordReset;
using BloodManagment.Application.features.Auth.Commandes.ResetPasswordWithOtp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Api.Contrrollers
{
    [ApiController]
    [Route("api/auth")]
    public class ApiAuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiAuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            try
            {
                var userId = await _mediator.Send(command); // Call CQRS command to create the user
                return Ok(new { UserId = userId, Message = "User registered successfully!" });
            }
            catch (Exception ex)
            {
                // Return a detailed error message in case of failure
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(ApiLoginCommand command)
        {
            var token = await _mediator.Send(command);

            return Ok(new { access_token = token });
        }

        [HttpPost("forgot-password-otp")]
        [AllowAnonymous]
        public async Task<IActionResult> RequestOtp([FromBody] string email)
        {
            await _mediator.Send(
                new RequestPasswordResetOtpCommand { Email = email });

            return Ok(new
            {
                message = "If the account exists, an OTP was sent."
            });
        }

        [HttpPost("reset-password-otp")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(
            ResetPasswordWithOtpCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Password reset successful" });
        }


    }

}
