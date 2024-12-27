using DepartmentEmp.Data;
using DepartmentEmp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
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
                var employee = _context.Employees.Include(e => e.Department)
                                                  .FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                ViewBag.Departments = _context.Departments.ToList();
                return View(employee);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int? id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string imagePath = null;

                    // Check if ImageData is provided
                    if (employee.ImageData != null)
                    {
                        Console.WriteLine($"Image uploaded: {employee.ImageData.FileName}");

                        // Generate a unique file name to avoid overwriting
                        var fileName = Path.GetFileNameWithoutExtension(employee.ImageData.FileName);
                        var extension = Path.GetExtension(employee.ImageData.FileName);
                        var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

                        try
                        {
                            // Save the file
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await employee.ImageData.CopyToAsync(stream);
                            }

                            imagePath = "/images/" + uniqueFileName;
                            Console.WriteLine($"Image successfully saved at: {filePath}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error saving file: {ex.Message}");
                            ModelState.AddModelError("", "Unable to save the image. Please check folder permissions.");
                            ViewBag.Departments = _context.Departments.ToList();
                            return View(employee);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No image uploaded.");
                    }

                    if (id == null)
                    {
                        // Creating a new employee
                        if (imagePath != null)
                        {
                            employee.ImageFilePath = imagePath;
                        }

                        _context.Employees.Add(employee);
                        Console.WriteLine("New employee added to the database.");
                    }
                    else
                    {
                        // Editing an existing employee
                        var existingEmployee = await _context.Employees.FindAsync(id);
                        if (existingEmployee == null)
                        {
                            Console.WriteLine($"Employee with ID {id} not found.");
                            return NotFound();
                        }

                        existingEmployee.Name = employee.Name;
                        existingEmployee.Email = employee.Email;
                        existingEmployee.DepartmentId = employee.DepartmentId;

                        if (imagePath != null)
                        {
                            existingEmployee.ImageFilePath = imagePath;
                            Console.WriteLine("Employee image updated.");
                        }

                        _context.Employees.Update(existingEmployee);
                        Console.WriteLine("Employee details updated in the database.");
                    }

                    await _context.SaveChangesAsync();
                    Console.WriteLine("Database changes saved successfully.");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Console.WriteLine("Model state is invalid.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                ModelState.AddModelError("", "An unexpected error occurred. Please try again.");
            }

            ViewBag.Departments = _context.Departments.ToList();
            return View(employee);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
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
