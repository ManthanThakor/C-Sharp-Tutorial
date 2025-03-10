using Microsoft.AspNetCore.Mvc;

namespace StudentCourseMvcAjaxJquery.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
