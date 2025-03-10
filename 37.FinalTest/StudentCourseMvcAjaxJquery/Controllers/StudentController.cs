using Microsoft.AspNetCore.Mvc;

namespace StudentCourseMvcAjaxJquery.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
