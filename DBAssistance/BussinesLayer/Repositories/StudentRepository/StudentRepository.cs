using DBAssistance.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Student> GetStudentAsync(int id)
        {
            return await _dbAssistenceContext.Student.Where(s => s.StudentId == id).FirstAsync();
        }

        public async Task<bool> StudentExistAsync(int id)
        {
            return await _dbAssistenceContext.Student.AnyAsync(s => s.StudentId == id);
        }

        public async Task<bool> CreateStudent(Student student)
        {
            _dbAssistenceContext.Student.Add(student);
            return await  SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbAssistenceContext.SaveChangesAsync() >= 0;
        }


    }
}
