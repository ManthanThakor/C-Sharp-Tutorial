using EmpDepWebAPI.Model;

namespace EmpDepWebAPI.Repository.RepoInter
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool SaveChanges();
    }
}
