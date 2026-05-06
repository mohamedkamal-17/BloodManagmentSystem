using BloodManagment.Application.Commane;
using BloodManagment.Application.features.Donarfeat.Commandes.CreateDonor;
using BloodManagment.Application.features.Donarfeat.Queries.CheckDonorExistByUserId;
using BloodManagment.Application.features.Donarfeat.Queries.GetByUserId;
using BloodManagment.Application.features.Donarfeat.Queries.GetDonarProfile;
using BloodManagment.Application.features.Donarfeat.Queries.PredictDonor;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodManagment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DonorsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrentUserService currentUserService;

    public DonorsController(IMediator mediator , ICurrentUserService currentUserService)
    {
        _mediator = mediator;
        this.currentUserService = currentUserService;
    }
    [HttpGet("predict-donor/{donorId}")]
    public async Task<IActionResult> PredictDonor(int donorId)
    {
        var result = await _mediator.Send(new PredictDonorByIdQuery
        {
            DonorId = donorId
        });

        return Ok(result);

     
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
    [HttpGet("exists/{userId}")]
    public async Task<IActionResult> CheckDonorExist(string userId)
    {
        var result = await _mediator.Send(new CheckDonorExistByUserIdQuery
        {
            UserId = userId
        });

        if (result)
        {
            return Ok(new { DonorExists = result });
        }
        else
        {
            return NotFound(new { Message = "Donor not found." });
        }
    }
    
    [HttpGet("user/profile")]
    
    public async Task<IActionResult> GetUserProfile()
    {
        // Extract UserId from claims (ensure it's part of the claims)
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // or use any other key like "userId"

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("User ID not found in claims");
        }

        // Query the data using the extracted userId
        var result = await _mediator.Send(new GetByUserIdQuery
        {
            UserId = userId
        });

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProfile(int id)
    {
        var result = await _mediator.Send(new GetDonarProfileQuery{ Id=id});

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}