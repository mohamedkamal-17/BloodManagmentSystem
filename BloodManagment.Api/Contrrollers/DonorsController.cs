using BloodManagment.Application.features.Donarfeat.Commandes.CreateDonor;
using BloodManagment.Application.features.Donarfeat.Queries.GetByUserId;
using BloodManagment.Application.features.Donarfeat.Queries.PredictDonor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DonorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("predict-donor/{donorId}")]
    public async Task<IActionResult> PredictDonor(int donorId)
    {
        var result = await _mediator.Send(new PredictDonorByIdQuery
        {
            DonorId = donorId
        });

        return Ok(result);

        //        < a href = "/api/yourcontroller/predict-donor/@donor.Id"
        //   class="btn btn-sm btn-outline-success">
        //   🔮 توقع
        //</a>
    }

    // =============================
    // Create Donor Profile
    // =============================
    [HttpPost]
    public async Task<IActionResult> Create(CreateDonorProfileCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetByUserId),
            new { userId = command.UserId },
            id);
    }

    // =============================
    // Get Donor By UserId
    // =============================
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(string userId)
    {
        var result = await _mediator.Send(new GetByUserIdQuery
        {
            UserId = userId
        });

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}