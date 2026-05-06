using BloodManagment.Application.features.Rescipientfeat.Commandes.CreateRescipientProfile;
using BloodManagment.Application.features.Rescipientfeat.Queries.CheckRecipientExistByUserId;
using BloodManagment.Application.features.Rescipientfeat.Queries.GetRescipientById;
using BloodManagment.Application.features.Rescipientfeat.Queries.GetRescipientByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodManagment.Api.Contrrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // =========================================
        // 🔍 Get Rescipient by Id
        // =========================================
        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetRecipientByIdQuery(id));

            if (result == null)
                return NotFound(new { message = "Rescipient not found" });

            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateRescipientProfileCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(new
            {
                message = "Rescipient profile created successfully",
                id = result
            });
        }

        // =========================================
        // 👤 Get Rescipient by UserId (from token)
        // =========================================
        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Invalid user token" });

            var result = await _mediator.Send(new GetRecipientByUserIdQuery(userId));

            if (result == null)
                return NotFound(new { message = "Rescipient not found" });

            return Ok(result);
        }

        // =========================================
        // 👤 Get Rescipient by UserId (manual)
        // =========================================
        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var result = await _mediator.Send(new GetRecipientByUserIdQuery(userId));

            if (result == null)
                return NotFound(new { message = "Rescipient not found" });

            return Ok(result);
        }

        [HttpGet("exists/{userId}")]
        public async Task<IActionResult> CheckRecipientExist(string userId)
        {
            var result = await _mediator.Send(new CheckRecipientExistByUserIdQuery
            {
                UserId = userId
            });

            if (result)
            {
                return Ok(new { RecipientExists = result });
            }
            else
            {
                return NotFound(new { Message = "Recipient not found." });
            }
        }
    }
}


