using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourse.Data;
using StudentCourse.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourse.Controllers
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return Json(courses);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Course added successfully!" });
            }
            return Json(new { success = false, message = "Validation failed." });
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Course updated successfully!" });
            }
            return Json(new { success = false, message = "Validation failed." });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return Json(new { success = false, message = "Course not found." });

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Course deleted successfully!" });
        }
    }
}
