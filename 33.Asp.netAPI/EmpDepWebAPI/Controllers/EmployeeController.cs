using EmpDepWebAPI.Model;
using EmpDepWebAPI.Repository.RepoInter;
using Microsoft.AspNetCore.Mvc;

namespace EmpDepWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees() =>
            Ok(_employeeRepository.GetAllEmployees().ToList());

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Invalid data.");

            _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            _employeeRepository.UpdateEmployee(employee);
            return NoContent();
        }

        // DELETE: api/Employees/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee == null)
                return NotFound();

            _employeeRepository.DeleteEmployee(employee);
            return NoContent();
        }
    }
}
