using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourse.Data;
using StudentCourse.Models;

namespace StudentCourse.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,DateOfBirth")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Student created successfully." });
            }
            return Json(new { success = false, message = "Failed to create student." });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Json(student);
        }


    }
}

