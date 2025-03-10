using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourseMvcAjaxJquery.Models.Data;
using StudentCourseMvcAjaxJquery.Models.Entity;

namespace StudentCourseMvcAjaxJquery.Controllers
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
            var enrollments = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToList();
            return View(enrollments);
        }

        [HttpGet]
        public IActionResult CreateEdit(int id = 0)
        {
            ViewBag.Students = new SelectList(_context.Students, "Id", "Name");
            ViewBag.Courses = new SelectList(_context.Courses, "Id", "Title");

            if (id == 0)
            {
                return PartialView("_CreateEdit", new Enrollment());
            }
            else
            {
                var enrollment = _context.Enrollments.Find(id);
                if (enrollment == null)
                {
                    return NotFound();
                }
                return PartialView("_CreateEdit", enrollment);
            }
        }

        [HttpPost]
        public IActionResult CreateEdit(Enrollment enrollment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Students = new SelectList(_context.Students, "Id", "Name");
                ViewBag.Courses = new SelectList(_context.Courses, "Id", "Title");
                return PartialView("_CreateEdit", enrollment);
            }

            if (enrollment.Id == 0)
            {
                _context.Enrollments.Add(enrollment);
            }
            else
            {
                _context.Enrollments.Update(enrollment);
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var enrollment = _context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return Json(new { success = false, message = "Enrollment not found." });
            }

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
            return Json(new { success = true, message = "Enrollment deleted successfully." });
        }
    }
}
