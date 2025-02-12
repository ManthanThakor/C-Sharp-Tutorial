using EmpDepWebAPI.EfCore;
using EmpDepWebAPI.Model;
using EmpDepWebAPI.Repository.RepoInter;
using Microsoft.EntityFrameworkCore;

namespace EmpDepWebAPI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmpDepDbContext _context;

        public DepartmentRepository(EmpDepDbContext context)
        {
            _context = context;
        }

        public IQueryable<Department> GetAllDepartments() => _context.Departments.Include(d => d.Employees);

        public Department GetDepartment(int id)
        {
            return _context.Departments
                           .Include(d => d.Employees)
                           .FirstOrDefault(d => d.Id == id);
        }


        public bool AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            return SaveChanges();
        }

        public bool UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            return SaveChanges();
        }

        public bool DeleteDepartment(Department department)
        {
            _context.Departments.Remove(department);
            return SaveChanges();
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
