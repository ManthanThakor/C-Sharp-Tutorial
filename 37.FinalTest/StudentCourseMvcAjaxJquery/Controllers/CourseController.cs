using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseMvcAjaxJquery.Models.Data;
using StudentCourseMvcAjaxJquery.Models.Entity;

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
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            var courses = await _context.Courses.ToListAsync();
            return Json(new { data = courses });
        }

        public async Task<IActionResult> CreateEdit(int? id)
        {
            if (id == null) return PartialView("_CourseForm", new Course());

            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            return PartialView("_CourseForm", course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEdit(Course course)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CourseForm", course);
            }

            if (course.Id == 0)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Course added successfully!" });
            }
            else
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Course updated successfully!" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return Json(new { success = false, message = "Course not found!" });

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Course deleted successfully!" });
        }
    }
}
