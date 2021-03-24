using EMobile.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMobile.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {

        [HttpGet(Name = nameof(GetRoot))]
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {
            var response = new RootResponse
            {
                Self = Link.To(nameof(GetRoot)),
                Mobiles = Link.To(nameof(MobilesController.GetMobiles))
            };

            return Ok(response);
        }
    }
}
