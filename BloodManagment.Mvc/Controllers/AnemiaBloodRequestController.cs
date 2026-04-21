using BloodManagment.Application.features.AnemiaBloodRequestfeat.Commandes.AssignDonorToThalassemiaPatient;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAllAnemiaBloodRequests;
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
    }
}
