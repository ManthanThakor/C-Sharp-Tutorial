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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Student added successfully!" });
            }
            return Json(new { success = false, message = "Validation failed." });
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Student updated successfully!" });
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
