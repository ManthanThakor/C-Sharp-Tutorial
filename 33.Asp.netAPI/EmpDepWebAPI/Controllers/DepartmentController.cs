using Microsoft.AspNetCore.Mvc;

namespace EmpDepWebAPI.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
