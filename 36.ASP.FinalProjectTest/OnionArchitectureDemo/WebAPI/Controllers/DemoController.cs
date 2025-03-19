using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "GET request received" });
        }

        [HttpPost]
        public IActionResult Post([FromBody] object data)
        {
            return Ok(new { message = "POST request received", receivedData = data });
        }
    }
}
