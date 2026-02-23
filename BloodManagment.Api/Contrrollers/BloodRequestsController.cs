using BloodManagment.Application.features.BloodRequestfeat.Commandes.CreatBloodRequest;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBloodRequests;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestesByBloodStatus;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetByUserId;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BloodRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BloodRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // ==============================
    // 1️⃣ Create Blood Request
    // ==============================
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatBloodRequestCommand command,
        CancellationToken cancellationToken)
    {
        var requestCode = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(
            nameof(GetAll),
            new { requestCode },
            new { requestCode });
    }

    // ==============================
    // 2️⃣ Get All Blood Requests
    // ==============================
    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetAllBloodRequestsQuery(),
            cancellationToken);

        return Ok(result);
    }

    // ==============================
    // 3️⃣ Get Blood Requests By Status
    // ==============================
    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(
        [FromRoute] RequestStatus status,
        CancellationToken cancellationToken)
    {
        var query = new GetBloodRequestesByStatuQuery
        {
            status = status
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    // ==============================
    // 4️⃣ Get Blood Requests By UserId
    // ==============================
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(
        [FromRoute] int userId,
        CancellationToken cancellationToken)
    {
        var query = new GetByUserIdQuery
        {
            UserId = userId
        };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}