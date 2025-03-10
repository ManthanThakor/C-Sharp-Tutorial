using Microsoft.AspNetCore.Mvc;
using StudentCourseMvcAjaxJquery.Models.Entity;
using StudentCourseMvcAjaxJquery.Models.Data;

namespace StudentCourseMvcAjaxJquery.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public IActionResult CreateEdit(int id = 0)
        {
            if (id == 0)
                return PartialView("_CreateEdit", new Course());
            else
            {
                var course = _context.Courses.Find(id);
                if (course == null) return NotFound();
                return PartialView("_CreateEdit", course);
            }
        }

        [HttpPost]
        public IActionResult CreateEdit(Course course)
        {
            if (!ModelState.IsValid)
                return PartialView("_CreateEdit", course);

            if (course.Id == 0)
                _context.Courses.Add(course);
            else
                _context.Courses.Update(course);

            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return Json(new { success = false, message = "Course not found." });

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return Json(new { success = true, message = "Course deleted successfully." });
        }
    }
}
