using BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetAllThalassemiaPatients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Mvc.Controllers
{

    public class ThalassemiaPatientsController : Controller
    {
        private readonly IMediator _mediator;

        public ThalassemiaPatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // 📄 GET: ThalassemiaPatients
        public async Task<IActionResult> Index()
        {
            var patients = await _mediator.Send(new GetAllThalassemiaPatientsQuery());

            return View(patients);
        }
    }
}

