using BloodManagment.Application.features.DonationRequestfeat.Commandes.AcceptDonationRequest;
using BloodManagment.Application.features.DonationRequestfeat.Commandes.RejectDonationRequestCommand;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests;
using BloodManagment.Mvc.ViewModels.DonationRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Mvc.Controllers
{

    public class DonationRequestController : Controller
    {
        private readonly IMediator mediator;

        public DonationRequestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await mediator.Send(new GetAllDonationRequestQuery());

            var vm = new DonationRequestListViewModel
            {
                Requests = result.Select(x => new DonationRequestViewModel
                {
                    Id = x.Id,
                    RequestCode = x.RequestCode,
                    RequestDate = x.RequestDate,
                    PreferredDonationDate = x.PreferredDonationDate,
                    Status = x.Statu,
                    DonarId = x.DonarId,
                    DonarName = x.DonarName,
                    HealthConditionId = x.HealthConditionId
                }).ToList()
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await mediator.Send(new GetDonationRequestByIdQuery
            {
                Id = id
            });

            var vm = new DonationRequestDetailsViewModel
            {
                Id = result.Id,
                RequestCode = result.RequestCode,
                RequestDate = result.RequestDate,
                PreferredDonationDate = result.PreferredDonationDate,
                Statu = result.Statu,
                DonarId = result.DonarId,
                DonarName = result.DonarName,

                HealthCondition = new HealthConditionViewModel
                {
                    HasAnemia = result.HealthCondition.HasAnemia,
                    HasJaundice = result.HealthCondition.HasJaundice,
                    HasHeartDisease = result.HealthCondition.HasHeartDisease,
                    HasCancer = result.HealthCondition.HasCancer,
                    HasDiabetes = result.HealthCondition.HasDiabetes,
                    HasAIDS = result.HealthCondition.HasAIDS,
                    HasCold = result.HealthCondition.HasCold,
                    IsPregnant = result.HealthCondition.IsPregnant,
                    HasSkinDisease = result.HealthCondition.HasSkinDisease,
                    HasBloodPressureIssue = result.HealthCondition.HasBloodPressureIssue,
                    HasRecentSurgery = result.HealthCondition.HasRecentSurgery
                }
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Accept(int id)
        {
            var result = await mediator.Send(new AcceptDonationRequestCommand { Id=id});

            if (!result)
                return NotFound();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Reject(int id)
        {
            var result = await mediator.Send(new RejectDonationRequestCommand { Id = id });

            if (!result)
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}
