using BloodManagment.Application.features.BloodUnitfeat.Commandes.CreateBloodUnit;
using BloodManagment.Application.features.BloodUnitfeat.Commandes.DeleteBloodUnit;
using BloodManagment.Application.features.BloodUnitfeat.Commandes.UpdateBloodUnit;
using BloodManagment.Application.features.BloodUnitfeat.Queries.GetAllBloodUnits;
using BloodManagment.Application.features.BloodUnitfeat.Queries.GetAvailableBloodUnits;
using BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitById;
using BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByBloodGroup;
using BloodManagment.Application.features.BloodUnitfeat.Queries.GetBloodUnitsByInventoryId;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BloodUnitsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BloodUnitsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // ============================
    // Create Blood Unit
    // ============================
    [HttpPost]
    public async Task<IActionResult> Create(CreateBloodUnitCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    // ============================
    // Update Blood Unit
    // ============================
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateBloodUnitCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await _mediator.Send(command);

        return NoContent();
    }

    // ============================
    // Update Blood Unit Status
    // ============================
    [HttpPut("status/{id}")]


    // ============================
    // Delete Blood Unit
    // ============================
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteBloodUnitCommand
        {
            Id = id
        });

        return NoContent();
    }

    // ============================
    // Get All Blood Units
    // ============================
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBloodUnitsQuery());

        return Ok(result);
    }

    // ============================
    // Get Blood Unit By Id
    // ============================
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetBloodUnitByIdQuery
        {
            Id = id
        });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // ============================
    // Get Units By Blood Group
    // ============================
    [HttpGet("blood-group/{bloodGroup}")]
    public async Task<IActionResult> GetByBloodGroup(BloodGroup bloodGroup)
    {
        var result = await _mediator.Send(
            new GetBloodUnitsByBloodGroupQuery(bloodGroup));

        return Ok(result);
    }

    // ============================
    // Get Available Blood Units
    // ============================
    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable()
    {
        var result = await _mediator.Send(new GetAvailableBloodUnitsQuery());

        return Ok(result);
    }

    // ============================
    // Get Units By Inventory
    // ============================
    [HttpGet("inventory/{inventoryId}")]
    public async Task<IActionResult> GetByInventory(int inventoryId)
    {
        var result = await _mediator.Send(
            new GetBloodUnitsByInventoryIdQuery(inventoryId));

        return Ok(result);
    }
}