using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IService<Department> _departmentService;

        public DepartmentController(IService<Department> departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetAll()
        {
            return Ok(_departmentService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public ActionResult Add(Department department)
        {
            _departmentService.Add(department);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Department department)
        {
            if (id != department.Id)
                return BadRequest();

            _departmentService.Update(department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
                return NotFound();

            _departmentService.Delete(id);
            return NoContent();
        }
    }
}
