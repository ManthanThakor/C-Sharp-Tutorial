using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ServiceInterface
{
    public interface IService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO?> GetStudentByIdAsync(int id);
        Task AddStudentAsync(StudentDTO studentDto);
        Task UpdateStudentAsync(StudentDTO studentDto);
        Task DeleteStudentAsync(int id);
    }
}
