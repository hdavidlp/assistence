using DBAssistance.BussinesLayer.Dto;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.CourseRepository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Task<Course> GetCourseAsync(int id);
        Task<bool> createCourse(Course course);
        Task<bool> DeleteCourse(Course course);
        Task<bool> UpdateCourse();
        Task<bool> CourseExistAsync(int id);
    }
}