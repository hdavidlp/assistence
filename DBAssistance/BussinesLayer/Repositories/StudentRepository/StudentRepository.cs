using DBAssistance.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Repositories.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DBAssistenceContext _dbAssistenceContext;

        public StudentRepository(DBAssistenceContext dbAssistenceContext)
        {
            _dbAssistenceContext = dbAssistenceContext ?? throw new ArgumentNullException(nameof(DBAssistenceContext));
        }

        public IEnumerable<Student> GetStudents()
        {
            return _dbAssistenceContext.Student.ToList();
        }

        public Student GetStudent(int id)
        {
            return _dbAssistenceContext.Student.Where(s => s.StudentId == id).FirstOrDefault();
        }


    }
}
