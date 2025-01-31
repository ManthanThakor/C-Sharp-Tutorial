using Microsoft.AspNetCore.Mvc;

namespace StudentCourse.Controllers
{
    public class EnrollmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
