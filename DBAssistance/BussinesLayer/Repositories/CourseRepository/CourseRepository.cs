using DBAssistance.BussinesLayer.Services.PeriodService;
using DBAssistance.DataLayer.Entities;
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
            _dbAssistenceContext = dbAssistenceContext ?? throw new ArgumentNullException(nameof(dbAssistenceContext));
        }

        public IEnumerable<Course> GetCourses()
        {
            return _dbAssistenceContext.Course.ToList();
        }

    }
}
