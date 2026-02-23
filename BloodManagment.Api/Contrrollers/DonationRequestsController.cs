using BloodManagment.Application.features.DonationRequestfeat.Commandes.CreateDonationRequest;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById;
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
    [Authorize(Roles = "Donor")]
    public async Task<IActionResult> Create(
        [FromBody] CreateDonationRequestCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new { id });
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
}