using EmpDepWebAPI.Model;

namespace EmpDepWebAPI.Repository.RepoInter
{
    public interface IDepartmentRepository
    {
        IQueryable<Department> GetAllDepartments();
        Department GetDepartment(int id);
        bool AddDepartment(Department department);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(Department department);
        bool SaveChanges();
    }
}
