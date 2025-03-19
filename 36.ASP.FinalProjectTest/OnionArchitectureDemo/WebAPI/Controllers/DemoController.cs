using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
