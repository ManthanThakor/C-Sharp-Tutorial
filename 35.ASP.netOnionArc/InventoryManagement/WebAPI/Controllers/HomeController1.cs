using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
