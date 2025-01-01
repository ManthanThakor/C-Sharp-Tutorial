using Microsoft.AspNetCore.Mvc;
using DepartmentEmp.Data;
using DepartmentEmp.Models;

namespace DepartmentEmp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        public IActionResult CreateEdit(int? id)
        {
            if (id == null)
            {
                return View(new Department());
            }
            else
            {
                var department = _context.Departments.Find(id);
                if (department == null)
                {
                    return NotFound();
                }
                return View(department);
            }
        }

        [HttpPost]
        public IActionResult CreateEdit(int? id, Department department)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    _context.Departments.Add(department);
                }
                else
                {
                    _context.Departments.Update(department);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
