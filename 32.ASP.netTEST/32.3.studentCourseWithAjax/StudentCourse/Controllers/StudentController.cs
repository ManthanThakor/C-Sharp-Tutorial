using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourse.Data;
using StudentCourse.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourse.Controllers
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Json(students);
        }


        [HttpGet]
        public IActionResult CreateEdit(int? id)
        {
            if (id == null)
            {
                return PartialView("CreateEdit", new Student());
            }

            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return PartialView("CreateEdit", student);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEdit([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {

                if (student.Id == 0)
                {
                    _context.Students.Add(student);
                }
                else
                {
                    _context.Students.Update(student);
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true, message = student.Id == 0 ? "Student added successfully!" : "Student updated successfully!" });
            }

            return Json(new { success = false, message = "Validation failed." });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return Json(new { success = false, message = "Student not found." });

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Student deleted successfully!" });
        }
    }

}