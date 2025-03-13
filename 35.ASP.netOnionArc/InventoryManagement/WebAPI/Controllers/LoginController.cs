using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
