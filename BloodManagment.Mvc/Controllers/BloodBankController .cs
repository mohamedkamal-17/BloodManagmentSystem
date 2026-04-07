using BloodManagment.Application.features.BloodInventoryfeat.Queries.GetAllInentory;
using BloodManagment.Mvc.ViewModels.BloodInvintory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Mvc.Controllers
{
    public class BloodBankController : Controller
    {
        private readonly IMediator mediatR;

        public BloodBankController(IMediator mediatR)
        {
            this.mediatR = mediatR;
        }

        public async Task<IActionResult> Index()
        {
            var result = await mediatR.Send(new GettAllInentoriesQuery());

            var vm = new BloodInventoryViewModel
            {
                Inventories = result.ToList()
            };

            return View(vm);
        }
    }
}
