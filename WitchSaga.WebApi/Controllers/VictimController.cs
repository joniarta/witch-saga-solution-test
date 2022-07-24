using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WitchSaga.Application.Services.Victim;
using WitchSaga.Application.Services.Victim.Dtos;
using WitchSaga.Application.Services.Victim.Requests;

namespace WitchSaga.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/victims")]
    [ApiController]
    public class VictimController : ControllerBase
    {
        private readonly IVictimService _service;

        public VictimController(IVictimService service)
        {
            this._service = service;
        }

        [HttpPost("average")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CalculateAverageVictims([FromBody]Models.CalculateAverageKillingModel model)
        {
            if (ModelState.IsValid)
            {
                var request = new CalculateAverageKillingRequest();

                foreach (var victim in model.Victims)
                {
                    request.Victims.Add(new Victim
                    {
                        AgeOfDeath = victim.AgeOfDeath,
                        YearOfDeath = victim.YearOfDeath
                    });
                }

                var response = this._service.CalculateAverageKilling(request);

                if (!response.HasError)
                {
                    return Ok(new { Average = response.Result, Error = new string[0] });
                }

                return BadRequest(new { Average = response.Result, Error = response.Exceptions.ToList() });
            }

            return BadRequest();
        }
    }
}
