using DepartmentEmp.Data;
using DepartmentEmp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: Employee/Index
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.Include(e => e.Department).ToListAsync();
            return View(employees);
        }

        // GET: Employee/CreateEdit
        public async Task<IActionResult> CreateEdit(int? id)
        {
            // If no id provided, creating a new employee
            if (id == null)
            {
                ViewData["DepartmentId"] = new SelectList(await _context.Departments.ToListAsync(), "Id", "Name");
                return View(new Employee()); // Empty employee model for create
            }

            // Editing an existing employee
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Populating the Department dropdown for the employee edit page
            ViewData["DepartmentId"] = new SelectList(await _context.Departments.ToListAsync(), "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employee/CreateEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(int? id, [Bind("Id,Name,Email,DepartmentId,imageData")] Employee employee, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                // If a file is uploaded, process the image
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        // Copy the uploaded file into memory
                        await imageFile.CopyToAsync(memoryStream);

                        // Store the image as byte[] in the employee object
                        employee.imageData = memoryStream.ToArray();
                    }
                }

                // If no image file is uploaded, set imageData to null (or empty byte array)
                else
                {
                    employee.imageData = null; // Or Array.Empty<byte>() if you want an empty array
                }

                if (id == null) // Creating a new employee
                {
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                }
                else // Editing an existing employee
                {
                    try
                    {
                        _context.Update(employee);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EmployeeExists(employee.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return RedirectToAction(nameof(Index)); // Redirect back to the employee list after successful creation/edit
            }

            // If model is invalid, re-populate the department dropdown and return the view with error messages
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee); // Return the view with validation errors
        }

        // Helper method to check if employee exists
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
