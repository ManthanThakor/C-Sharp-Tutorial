using Microsoft.AspNetCore.Mvc;

namespace StudentCourse.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
