using Application.DTO;
using Application.Services.ServiceInterface;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class Service : IService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Course> _courseRepository;

        public Service(IRepository<Student> studentRepository, IRepository<Course> courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                CourseId = s.CourseId,
                CourseTitle = s.Course?.Title
            }).ToList();
        }

        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return null;

            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                CourseId = student.CourseId,
                CourseTitle = student.Course?.Title
            };
        }

        public async Task AddStudentAsync(StudentDTO studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                CourseId = studentDto.CourseId
            };
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(StudentDTO studentDto)
        {
            var student = await _studentRepository.GetByIdAsync(studentDto.Id);
            if (student != null)
            {
                student.Name = studentDto.Name;
                student.CourseId = studentDto.CourseId;
                await _studentRepository.UpdateAsync(student);
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student != null)
            {
                await _studentRepository.DeleteAsync(student);
            }
        }
    }
}
