using AutoMapper;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.BussinesLayer.Services.PeriodService;
using DBAssistance.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Repositories.CourseRepository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DBAssistenceContext _dbAssistenceContext;


        public CourseRepository(DBAssistenceContext dbAssistenceContext)
        {
            _dbAssistenceContext = dbAssistenceContext ?? 
                throw new ArgumentNullException(nameof(dbAssistenceContext));
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            var courseSelected = await _dbAssistenceContext.Course.
                Where(c => c.CourseID == id).FirstAsync();

            return courseSelected;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _dbAssistenceContext.Course.ToList();
        }

        public async Task <bool> createCourse(Course course)
        {
            _dbAssistenceContext.Course.Add(course);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteCourse(Course course)
        {
            _dbAssistenceContext.Course.Remove(course);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbAssistenceContext.SaveChangesAsync() >= 0;
        }


    }
}
