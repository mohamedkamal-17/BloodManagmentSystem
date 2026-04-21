using BloodManagment.Application.features.Donarfeat.Commandes.DeleteDonor;
using BloodManagment.Application.features.Donarfeat.Queries.GetAllDonors;
using BloodManagment.Application.features.Donarfeat.Queries.PredictDonor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace BloodManagment.Mvc.Controllers
{

    public class DonarController : Controller
    {
        private readonly IMediator _mediator;

        public DonarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // 📄 GET: Donar
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllDonorsQuery());
            return View(result);
        }

        // ➕ GET: Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ➕ POST: Create
        //[HttpPost]
        //public async Task<IActionResult> Create(CreateDonorCommand command)
        //{
        //    if (!ModelState.IsValid)
        //        return View(command);

        //    await _mediator.Send(command);
        //    return RedirectToAction(nameof(Index));
        //}

        //// ✏️ GET: Edit
        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var donor = await _mediator.Send(new GetDonorByIdQuery { Id = id });
        //    return View(donor);
        //}

        //// ✏️ POST: Edit
        //[HttpPost]
        //public async Task<IActionResult> Edit(UpdateDonorCommand command)
        //{
        //    if (!ModelState.IsValid)
        //        return View(command);

        //    await _mediator.Send(command);
        //    return RedirectToAction(nameof(Index));
        //}

        //// 🗑 Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteDonorCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }

        // 🔮 Predict donor behavior
        [HttpGet]
        public async Task<IActionResult> Predict(int id)
        {
            var result = await _mediator.Send(new PredictDonorByIdQuery
            {
                DonorId = id
            });

            return View("PredictionResult", result);
        }
    }
}
