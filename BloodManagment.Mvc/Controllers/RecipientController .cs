using BloodManagment.Application.features.Rescipientfeat.Queries.GetAllRecipients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Mvc.Controllers
{
    public class RecipientController : Controller
    {
        private readonly IMediator _mediator;

        public RecipientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _mediator.Send(new GetAllRecipientsQuery());
            return View(data);
        }
    }
}
