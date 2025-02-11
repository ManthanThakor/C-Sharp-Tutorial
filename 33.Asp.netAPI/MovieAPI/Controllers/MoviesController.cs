using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
