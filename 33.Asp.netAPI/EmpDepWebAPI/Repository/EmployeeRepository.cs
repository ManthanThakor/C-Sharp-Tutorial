using EmpDepWebAPI.EfCore;
using EmpDepWebAPI.Model;
using EmpDepWebAPI.Repository.RepoInter;
using Microsoft.EntityFrameworkCore;

namespace EmpDepWebAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpDepDbContext _context;

        public EmployeeRepository(EmpDepDbContext context)
        {
            _context = context;
        }

        public IQueryable<Employee> GetAllEmployees() => _context.Employees.Include(e => e.Department);

        public Employee GetEmployee(int id) => _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);

        public bool AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            return SaveChanges();
        }

        public bool UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            return SaveChanges();
        }

        public bool DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            return SaveChanges();
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
