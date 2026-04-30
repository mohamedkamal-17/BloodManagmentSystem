using BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.ApproveAnemiaRequest;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.AssignDonorToThalassemiaPatient;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.RejectAnemiaRequest;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAllAnemiaBloodRequests;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestById;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAssignScreenData;
using BloodManagment.Mvc.ViewModels.AnemiaBloodRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Mvc.Controllers
{
    public class AnemiaBloodRequestController : Controller
    {
        private readonly IMediator _mediator;

        public AnemiaBloodRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllAnemiaBloodRequestQuery());

            var vm = result.Select(x => new AnemiaBloodRequestVm
            {
                Id = x.Id,
                RequestCode = x.RequestCode,
                RequestDate = x.RequestDate,
                BloodGroup = x.BloodGroup,
                Status = x.Status,
                ResponsibleEntity = x.ResponsibleEntity,
                AttendanceDate = x.AttendanceDate,
                BloodTestDate = x.BloodTestDate,
                LastTransfusionDate = x.LastTransfusionDate,
                HemoglobinLevel = x.HemoglobinLevel,
                BloodTestIssuer = x.BloodTestIssuer,
                PatientId = x.PatientId
            }).ToList();

            return View(vm);
        }
        // 🟢 Step 1: Open Assign Page
        [HttpGet]
        public async Task<IActionResult> Assign(int requestId)
        {
            var vm = await _mediator.Send(new GetAssignScreenDataQuery
            {
                RequestId = requestId
            });

            return View(vm);
        }

        // 🔴 Step 2: Submit Assignment
        [HttpPost]
        public async Task<IActionResult> Assign(AssignDonorToThalassemiaPatientCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
            {
                return RedirectToAction("AssignSuccess", new
                {
                    patientId = command.ThalassemiaPatientId
                });
            }

            return RedirectToAction("Index");
        }

        public IActionResult AssignSuccess(int requestId)
        {
            ViewBag.RequestId = requestId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            await _mediator.Send(new ApproveAnemiaRequestCommand { Id = id });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {
            await _mediator.Send(new RejectAnemiaRequestCommand { Id = id });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _mediator.Send(new GetAnemiaBloodRequestByIdQuery(id));

            if (result == null)
                return NotFound();
            AnemiaBloodRequestVm vm = new AnemiaBloodRequestVm
            {
                Id = result.Id,
                RequestCode = result.RequestCode,
                RequestDate = result.RequestDate,
                BloodGroup = result.BloodGroup,
                Status = result.Status,
                ResponsibleEntity = result.ResponsibleEntity,
                AttendanceDate = result.AttendanceDate,
                BloodTestDate = result.BloodTestDate,
                LastTransfusionDate = result.LastTransfusionDate,
                HemoglobinLevel = result.HemoglobinLevel,
                BloodTestIssuer = result.BloodTestIssuer,
                PatientId = result.PatientId
            };

            return View(vm);
        }
    }
}
