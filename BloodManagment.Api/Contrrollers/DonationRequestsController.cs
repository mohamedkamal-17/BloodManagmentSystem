using BloodManagment.Application.features.DonationRequestfeat.Commandes.CreateDonationRequest;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestsByUserId;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByDonarId;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetPendingDonationRequestByDonor;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DonationRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    //[Authorize(Roles = "Donor")]
    public async Task<IActionResult> Create(
        [FromBody] CreateDonationRequestCommand command,
        CancellationToken cancellationToken)
    {
        var masseg = await _mediator.Send(command, cancellationToken);
        if (masseg == null)
            return BadRequest(new
            { 
                message = " user id not correct"
            });
        return Ok(new
        {
            id= masseg
        });
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetDonationRequestByIdQuery { Id = id },
            cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,LabTechnician")]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetAllDonationRequestQuery(),
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("status/{status}")]
    [Authorize(Roles = "Admin,LabTechnician")]
    public async Task<IActionResult> GetByStatus(
        RequestStatus status,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetDonationRequestsByStatuQuery { Statu = status },
            cancellationToken);

        return Ok(result);
    }

    [HttpGet("donor/{donorId:int}/pending")]
    [Authorize]
    public async Task<IActionResult> GetPendingByDonor(
        int donorId,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new PendingDonationRequestByDonorQuery
            {
                DonorId = donorId
            },
            cancellationToken);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
    //[HttpGet("donor/{donorId:int}")]
    ////   [Authorize] // Optionally you can add authorization if needed
    //public async Task<IActionResult> GetDonationRequestsByUserId(int userId)
    //{
    //    // Use MediatR to call the handler and fetch the data
    //    var result = await _mediator.Send(new GetDonationRequstsByUserIdQuery
    //    {
    //        UserId = userId
    //    });

    //    // If no data is found
    //    if (result == null || result.Count == 0)
    //    {
    //        return NotFound(new { Message = "No donation requests found for this user." });
    //    }

    //    return Ok(result); // Return the donation requests as JSON
    //}[HttpGet("donor/{donorId:int}")]
    // [Authorize] // Optionally you can add authorization if needed
    [HttpGet("donor/{donorId:int}")]
    public async Task<IActionResult> GetDonationRequestsByUserId(int donorId)
    {
        // Use MediatR to call the handler and fetch the data
        var result = await _mediator.Send(new GetDonationRequstsByDonarIdQuery
        {
            UserId = donorId // Use donorId as the UserId in the query
        });

        // If no data is found
        if (result == null || result.Count == 0)
        {
            return NotFound(new { Message = "No donation requests found for this donor." });
        }

        return Ok(result); // Return the donation requests as JSON
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetDonationRequestsByUserId(string userId)
    {
        // Send the query to MediatR to fetch donation requests by UserId
        var result = await _mediator.Send(new GetDonationRequestsByUserIdQuery
        {
            UserId = userId
        });

        if (result == null || result.Count == 0)
        {
            return NotFound(new { Message = "No donation requests found for this user." });
        }

        return Ok(result); // Return the donation requests as JSON
    }
}
