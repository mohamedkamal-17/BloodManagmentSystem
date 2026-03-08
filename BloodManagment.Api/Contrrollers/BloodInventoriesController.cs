using BloodManagment.Application.features.BloodInventoryfeat.Commandes.CreateBloodInventory;
using BloodManagment.Application.features.BloodInventoryfeat.Commandes.UpdateBloodInventory;
using BloodManagment.Application.features.BloodInventoryfeat.Queries.GetAllInentory;
using BloodManagment.Application.features.BloodInventoryfeat.Queries.GetBloodInventoryById;
using BloodManagment.Application.features.BloodInventoryfeat.Queries.GetInventoryByBloodGroup;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BloodInventoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public BloodInventoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // =============================
    // Create Blood Inventory
    // =============================
    [HttpPost]
    public async Task<IActionResult> Create(CreateBloodInventoryCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            id);
    }

    // =============================
    // Update Blood Inventory
    // =============================
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateBloodInventoryCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await _mediator.Send(command);

        return NoContent();
    }

    // =============================
    // Get All Inventories
    // =============================
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GettAllInentoriesQuery());

        return Ok(result);
    }

    // =============================
    // Get Inventory By Id
    // =============================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetBloodInventoryByIdQuery
        {
            Id = id
        });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // =============================
    // Get Inventory By Blood Group
    // =============================
    [HttpGet("blood-group/{bloodGroup}")]
    public async Task<IActionResult> GetByBloodGroup(BloodGroup bloodGroup)
    {
        var result = await _mediator.Send(
            new GetInventoryByBloodGroupQuery(bloodGroup));

        return Ok(result);
    }
}