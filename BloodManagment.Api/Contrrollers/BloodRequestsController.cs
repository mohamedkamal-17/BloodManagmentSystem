using BloodManagment.Application.features.BloodRequestfeat.Commandes.CreatBloodRequest;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBloodRequests;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestesByBloodStatus;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestsByUserIdQuery;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetByRecipientId;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetCreateBloodRequestData;
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
        if 
            (requestCode == null)
            return BadRequest(new
            {
                message = "Invalid HospitalId or UserId."
            });
        return Ok(new
        {
            RequestCode = requestCode
        });
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
    [HttpGet("create-data")]
    public async Task<IActionResult> GetCreateData()
    {
        var result = await _mediator.Send(new GetCreateBloodRequestDataQuery());

        return Ok(result);
    }
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetBloodRequestsByUserId(string userId)
    {
        var result = await _mediator.Send(new GetBloodRequestsByUserIdQuery
        {
            UserId = userId
        });

        if (result == null || result.Count == 0)
        {
            return NotFound(new { Message = "No blood requests found for this user." });
        }

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
        var query = new GetByRecipientIdQuery
        {
            UserId = userId
        };

        var result = await _mediator.Send(query, cancellationToken);
        if (result == null)
            return NotFound(new
            {
                message=$"No blood requests found for user with ID {userId}."
            });

        return Ok(result);
    }
}