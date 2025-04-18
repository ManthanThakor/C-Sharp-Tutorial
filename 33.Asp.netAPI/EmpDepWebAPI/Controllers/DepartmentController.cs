﻿using EmpDepWebAPI.Model;
using EmpDepWebAPI.Repository.RepoInter;
using Microsoft.AspNetCore.Mvc;

namespace EmpDepWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetAllDepartments() =>
            Ok(_departmentRepository.GetAllDepartments().ToList());

        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            var department = _departmentRepository.GetDepartment(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public ActionResult<Department> CreateDepartment([FromBody] Department department)
        {
            if (department == null)
                return BadRequest("Invalid data.");

            _departmentRepository.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDepartment(int id, [FromBody] Department department)
        {
            if (id != department.Id)
                return BadRequest();

            _departmentRepository.UpdateDepartment(department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetDepartment(id);
            if (department == null)
                return NotFound();

            _departmentRepository.DeleteDepartment(department);
            return NoContent();
        }
    }
}

