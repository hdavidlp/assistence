using AutoMapper;
using DBAssistance.BussinesLayer.Dto.Course;
using DBAssistance.BussinesLayer.Repositories.CourseRepository;
using DBAssistance.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _mapper= mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<Course> GetCourses()
        {
            return _courseRepository.GetCourses();
        }

        public IEnumerable<CourseDto> GetCoursesDto()
        {
            var courses = _courseRepository.GetCourses();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public CourseDto GetCourseByID(int id)
        {
            var courseSelected =   _courseRepository.GetCourseAsync(id);
            return _mapper.Map<CourseDto>(courseSelected);
        }

        public async Task<bool> createCourse(Course course)
        {
            return await _courseRepository.createCourse(course);
        }
        
        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetCourseAsync(id);

        }

        public async Task<bool> DeleteCourse(Course course)
        {
            return await _courseRepository.DeleteCourse(course);
        }

    }
}
