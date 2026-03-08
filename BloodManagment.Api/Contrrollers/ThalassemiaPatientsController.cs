using MediatR;
using Microsoft.AspNetCore.Mvc;

using BloodManagment.Application.features.ThalassemiaPatientfeat.Commandes.CreateThalassemiaPatientProfile;
using BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetAllThalassemiaPatients;
using BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientByIdQuery;
using BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientByUserId;
using BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientsByBloodGroup;
using BloodManagment.domain.Entities;

namespace BloodManagment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ThalassemiaPatientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ThalassemiaPatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // =============================
    // Create Thalassemia Patient
    // =============================
    [HttpPost]
    public async Task<IActionResult> Create(CreateThalassemiaPatientProfileCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            id);
    }

    // =============================
    // Get All Patients
    // =============================
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllThalassemiaPatientsQuery());

        return Ok(result);
    }

    // =============================
    // Get Patient By Id
    // =============================
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetThalassemiaPatientByIdQuery(id));

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // =============================
    // Get Patient By UserId
    // =============================
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(string userId)
    {
        var result = await _mediator.Send(new GetThalassemiaPatientByUserIdQuery
        {
            UserId = userId
        });

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // =============================
    // Get Patients By BloodGroup
    // =============================
    [HttpGet("blood-group/{bloodGroup}")]
    public async Task<IActionResult> GetByBloodGroup(BloodGroup bloodGroup)
    {
        var result = await _mediator.Send(
            new GetThalassemiaPatientsByBloodGroupQuery(bloodGroup));

        return Ok(result);
    }
}