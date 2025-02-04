using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourse.Data;
using StudentCourse.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourse.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetEnrollments()
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Select(e => new
                {
                    e.Id,
                    StudentName = e.Student.Name,
                    CourseTitle = e.Course.Title
                }).ToListAsync();

            return Json(enrollments);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Enrollment added successfully!" });
            }
            return Json(new { success = false, message = "Validation failed." });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null) return Json(new { success = false, message = "Enrollment not found." });

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Enrollment deleted successfully!" });
        }
    }
}
