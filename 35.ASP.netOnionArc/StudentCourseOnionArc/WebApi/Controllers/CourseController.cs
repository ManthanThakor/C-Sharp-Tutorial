using Application.Services.ServiceInterface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAllCourses()
        {
            var courses = _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public IActionResult AddCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Invalid course data.");
            }
            course.Students = new List<Student>();

            _courseService.AddCourse(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {
            if (course == null || course.Id != id)
            {
                return BadRequest("Invalid course data.");
            }

            var existingCourse = _courseService.GetCourseById(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            _courseService.UpdateCourse(course);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            _courseService.DeleteCourse(id);
            return NoContent();
        }
    }
}
