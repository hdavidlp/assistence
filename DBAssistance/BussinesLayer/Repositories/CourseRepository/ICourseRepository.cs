using DBAssistance.BussinesLayer.Dto;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.CourseRepository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(int id);
    }
}