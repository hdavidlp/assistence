using DBAssistance.BussinesLayer.Dto.Course;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.CourseService
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
        IEnumerable<CourseDto> GetCoursesDto();
        CourseDto GetCourseByID(int id);
        Task<bool> createCourse(Course course);
        Task<Course> GetCourseByIdAsync(int id);
        Task<bool> DeleteCourse(Course course);
    }
}