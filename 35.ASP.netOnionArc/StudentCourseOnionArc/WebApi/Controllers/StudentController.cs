using Application.Services.ServiceInterface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid student data.");
            }

            _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            if (student == null || student.Id != id)
            {
                return BadRequest("Invalid student data.");
            }

            var existingStudent = _studentService.GetStudentById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            _studentService.UpdateStudent(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
