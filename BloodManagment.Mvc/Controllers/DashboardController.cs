using BloodManagment.Application.features.Dashboardfeat.Queries.GetDashboardData;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMediator mediator;

        public DashboardController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var dashboardData = await mediator.Send(new GetDashboardDataQuery());

            return View(dashboardData);
        }
    }
}
