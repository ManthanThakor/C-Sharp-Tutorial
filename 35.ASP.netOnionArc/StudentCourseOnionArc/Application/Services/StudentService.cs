using Application.Services.ServiceInterface;
using Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure.Repositories.StudentCourseRepo;
using System.Collections.Generic;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetStudentsWithCourse();
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student != null)
            {
                _studentRepository.Delete(student);
            }
        }
    }
}
