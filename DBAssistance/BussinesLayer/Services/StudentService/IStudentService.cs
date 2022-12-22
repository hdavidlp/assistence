using DBAssistance.BussinesLayer.Dto;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.StudentService
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        IEnumerable<StudentDto> GetStudentsDto();
        StudentDto GetStudentDto(int id);
    }
}