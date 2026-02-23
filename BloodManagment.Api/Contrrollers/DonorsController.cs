using BloodManagment.Application.Extension;
using BloodManagment.Application.features.Donarfeat.Commandes.CreateDonor;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodManagment.Api.Contrrollers
{
    [ApiController]
    [Route("api/donors")]
    [Authorize(AuthenticationSchemes = AuthSchemes.Jwt)]
    public class DonorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("profile")]
        public async Task<IActionResult> CreateProfile(
            CreateDonorProfileCommand command)
        {
            var donorId = await _mediator.Send(command);
            return Ok(new { DonorId = donorId });
        }
    }

}
