using CRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CrudContext _context = new CrudContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}
