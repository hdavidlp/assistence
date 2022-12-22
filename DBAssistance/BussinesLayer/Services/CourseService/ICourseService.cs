using DBAssistance.BussinesLayer.Dto;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.CourseService
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
        IEnumerable<CourseDto> GetCoursesDto();
        CourseDto GetCourseByID(int id);
    }
}