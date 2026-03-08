using BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBloodRequests;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestesByBloodStatus;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetByBloodGroup;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetUrgentRequests;
using BloodManagment.domain.Entities;
using BloodManagment.Mvc.ViewModels.BloodRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class BloodRequestsController : Controller
{
    private readonly IMediator _mediator;

    public BloodRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // ================================
    // Received Requests Page
    // ================================
    public async Task<IActionResult> Index()
    {
        var result = await _mediator.Send(new GetAllBloodRequestsQuery());

        var model = result.Select(r => new BloodRequestCardVM
        {
            Id = r.Id,
            RequestNumber = r.RequestNumber,
            PatientName = r.PatientName,
            BloodGroup = r.BloodGroup.ToString(),
            Status = r.Status.ToString(),
            RequestType = r.Type.ToString(),
            RequiredDate = r.RequiredDate,
            HospitalName = r.HospitalName,
            Contributors = r.Contributors
        });

        return View(model);
    }

    // ================================
    // Urgent Requests
    // ================================
    public async Task<IActionResult> Urgent()
    {
        var result = await _mediator.Send(new GetUrgentBloodRequestsQuery());

        return View("Index", result);
    }

    // ================================
    // Filter By Blood Group
    // ================================
    public async Task<IActionResult> ByBloodGroup(BloodGroup bloodGroup)
    {
        var result = await _mediator.Send(
            new GetByBloodGroupQuery { BloodGroup = bloodGroup });

        return View("Index", result);
    }

    // ================================
    // Filter By Status
    // ================================
    public async Task<IActionResult> ByStatus(RequestStatus status)
    {
        var result = await _mediator.Send(
            new GetBloodRequestesByStatuQuery { status = status });

        return View("Index", result);
    }

    // ================================
    // Requests By User
    // ================================
    public async Task<IActionResult> ByUser(int userId)
    {
        var result = await _mediator.Send(
            new GetByUserIdQuery { UserId = userId });

        return View("Index", result);
    }
}