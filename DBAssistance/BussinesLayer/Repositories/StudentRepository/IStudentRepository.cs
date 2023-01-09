using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.StudentRepository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        Task<Student> GetStudentAsync(int id);
        Task<bool> StudentExistAsync(int id);
        Task<bool> CreateStudent(Student student);
    }
}