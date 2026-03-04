using BloodManagment.Application.Extension;
using BloodManagment.Application.features.Auth.Commandes.MvcLogin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Mvc.Controllers
{

    [Authorize(AuthenticationSchemes = AuthSchemes.Cookie)]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]

        [HttpGet]
        [HttpGet]
        public IActionResult Login()
        {
            return View(new MvcLoginCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Login(MvcLoginCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var result = await _mediator.Send(command);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "البريد الإلكتروني أو كلمة المرور غير صحيحة");
            return View(command);
        }
    }
}
