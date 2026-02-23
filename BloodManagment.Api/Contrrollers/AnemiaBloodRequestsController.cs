using BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.NewFolder;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAllAnemiaBloodRequests;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByStatu;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByUserId;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestsByBloodGroup;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Api.Contrrollers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AnemiaBloodRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnemiaBloodRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // =====================================================
        // 1️⃣ Create Anemia Blood Request
        // =====================================================
        [HttpPost]
        [Authorize] // optional depending on your system
        public async Task<IActionResult> Create(
            [FromBody] CreateAnemiaBloodRequestCommand command,
            CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(
                nameof(GetAll),
                new { id },
                new { id });
        }

        // =====================================================
        // 2️⃣ Get All Anemia Blood Requests
        // =====================================================
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetAllAnemiaBloodRequestQuery(),
                cancellationToken);

            return Ok(result);
        }

        // =====================================================
        // 3️⃣ Get By Status
        // =====================================================
        [HttpGet("status/{status}")]
        [Authorize]
        public async Task<IActionResult> GetByStatus(
            [FromRoute] RequestStatus status,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetAnemiaBloodRequestByStatuQuery
                {
                    Status = status
                },
                cancellationToken);

            return Ok(result);
        }

        // =====================================================
        // 4️⃣ Get By UserId
        // =====================================================
        [HttpGet("user/{userId:int}")]
        [Authorize]
        public async Task<IActionResult> GetByUserId(
            [FromRoute] int userId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetAnemiaBloodRequestByUserIdQuery
                {
                    UserId = userId
                },
                cancellationToken);

            return Ok(result);
        }

        // =====================================================
        // 5️⃣ Get By BloodGroup
        // =====================================================
        [HttpGet("blood-group/{bloodGroup}")]
        [Authorize]
        public async Task<IActionResult> GetByBloodGroup(
            [FromRoute] BloodGroup bloodGroup,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetAnemiaBloodRequestByBloodGroupQuery
                {
                    BloodGroup = bloodGroup
                },
                cancellationToken);

            return Ok(result);
        }
    }
}
