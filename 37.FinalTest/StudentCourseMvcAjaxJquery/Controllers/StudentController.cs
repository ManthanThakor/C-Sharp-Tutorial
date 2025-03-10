using Microsoft.AspNetCore.Mvc;
using StudentCourseMvcAjaxJquery.Models.Data;
using StudentCourseMvcAjaxJquery.Models.Entity;

namespace StudentCourseMvcAjaxJquery.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult CreateEdit(int id = 0)
        {
            if (id == 0)
            {
                return PartialView("_CreateEdit", new Student());
            }
            else
            {
                var student = _context.Students.Find(id);
                if (student == null)
                {
                    return NotFound();
                }
                return PartialView("_CreateEdit", student);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEdit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CreateEdit", student);
            }

            if (student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                _context.Students.Update(student);
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return Json(new { success = false, message = "Student not found." });
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            return Json(new { success = true, message = "Student deleted successfully." });
        }
    }
}
