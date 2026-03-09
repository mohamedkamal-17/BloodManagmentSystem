using BloodManagment.Application.features.BloodRequestfeat.Commandes.AcceptBloodRequest;
using BloodManagment.Application.features.BloodRequestfeat.Commandes.DeleteBloodRequest;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBloodRequests;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestDetails;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetByBloodGroup;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetCreateBloodRequestData;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetUrgentRequests;
using BloodManagment.domain.Entities;
using BloodManagment.Mvc.ViewModels.BloodRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodManagment.Mvc.Controllers
{
    public class BloodRequestController : Controller
    {
        private readonly IMediator _mediator;

        public BloodRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Main Screen
        public async Task<IActionResult> Index()
        {
            var requests = await _mediator.Send(new GetAllBloodRequestsQuery());

            return View(requests);
        }

        public async Task<IActionResult> Details(int id)
        {
            var dto = await _mediator.Send(new GetBloodRequestDetailsQuery(id));


            var requests = await _mediator.Send(new GetAllBloodRequestsQuery());


            if (dto == null)
                return NotFound();
            // 2. Map DTO → ViewModel
            var vm = new BloodRequestDetailsVM
            {
                Id = dto.Id,
                RequestNumber = dto.RequestCode,
                PatientName = dto.PatientName,
                BloodGroup = dto.BloodGroup, // optional helper for enums
                PhoneNumber = "", // populate if available
                Disease = dto.Reason,
                Hospital = dto.HospitalName,
                Gender = "", // populate if available
                BirthDate = DateTime.MinValue, // populate if available
                RequiredDate = dto.RequestDate,
                Status = dto.Status // optional helper
            };
            ViewBag.Details = vm;
            return View("Index", requests);


        }

        // Filter By Blood Group
        public async Task<IActionResult> ByBloodGroup(BloodGroup group)
        {
            var result = await _mediator.Send(new GetByBloodGroupQuery
            {
                BloodGroup = group
            });

            return View("Index", result);
        }

        [HttpPost]
        public async Task<IActionResult> Accept(int id)
        {
            await _mediator.Send(new AcceptBloodRequestCommand(id));

            return RedirectToAction(nameof(Index));
        }

        // Urgent Requests
        public async Task<IActionResult> Urgent()
        {
            var result = await _mediator.Send(new GetUrgentBloodRequestsQuery());

            return View("Index", result);
        }

        // Create View
        public async Task<IActionResult> Create()
        {
            var data = await _mediator.Send(new GetCreateBloodRequestDataQuery());

            var vm = new CreateBloodRequestVM
            {
                Hospitals = data.Hospitals
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList(),

                Recipients = data.Recipients
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList(),

                LabTechnicians = data.LabTechnicians
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList(),

                BloodGroups = data.BloodGroups
                    .Select(x => new SelectListItem(x, x))
                    .ToList()
            };

            return View(vm);
        }

        // Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBloodRequestVM vm)
        {
            if (!ModelState.IsValid)
            {
                // reload dropdown data
                var data = await _mediator.Send(new GetCreateBloodRequestDataQuery());

                vm.Hospitals = data.Hospitals
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

                vm.Recipients = data.Recipients
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

                vm.LabTechnicians = data.LabTechnicians
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();

                vm.BloodGroups = data.BloodGroups
                    .Select(x => new SelectListItem(x, x))
                    .ToList();

                return View(vm);
            }

            await _mediator.Send(vm.Command);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBloodRequestCommand(id));

            return RedirectToAction(nameof(Index));
        }
    }
}