using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet("protected")]
        public IActionResult ProtectedEndpoint()
        {
            return Ok("You are authorized!");
        }

        [AllowAnonymous]
        [HttpGet("nonProtectedEndpoint")]
        public IActionResult NonProtectedEndpoint()
        {
            return Ok("public Endpoint every one acsess this route!");
        }
    }

}