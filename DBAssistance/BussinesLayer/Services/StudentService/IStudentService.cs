using DBAssistance.BussinesLayer.Dto.Student;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.StudentService
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        IEnumerable<StudentDto> GetStudentsDto();
        StudentDto GetStudentDto(int id);
        Task<StudentDto> GetStudentAsync(int id);
        Task<bool> CreateStudent(Student student);
    }
}