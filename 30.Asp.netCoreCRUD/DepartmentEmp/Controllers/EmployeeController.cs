using DepartmentEmp.Data;
using DepartmentEmp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.IO;
using System.Threading.Tasks;

namespace DepartmentEmp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            return View(employees);
        }

        public IActionResult CreateEdit(int? id)
        {
            if (id == null)
            {
                ViewBag.Departments = _context.Departments.ToList();
                return View(new Employee());
            }
            else
            {
                var employee = _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                ViewBag.Departments = _context.Departments.ToList();
                return View(employee);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEdit(int? id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(employee.ImageFile.FileName);
                    string extension = Path.GetExtension(employee.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await employee.ImageFile.CopyToAsync(fileStream);
                    }

                    employee.ImagePath = "/images/" + fileName;
                }

                if (id == null)
                {
                    _context.Employees.Add(employee);
                }
                else
                {
                    _context.Employees.Update(employee);
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = _context.Departments.ToList();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
