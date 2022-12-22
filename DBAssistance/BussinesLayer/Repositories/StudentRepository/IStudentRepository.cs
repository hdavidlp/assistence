using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.StudentRepository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
    }
}