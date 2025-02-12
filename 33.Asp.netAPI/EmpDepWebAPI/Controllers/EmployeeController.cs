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

        // GET: api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees() =>
            Ok(_employeeRepository.GetAllEmployees().ToList());

        // GET: api/Employees/{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Invalid data.");

            _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT: api/Employees/{id}
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
