using DBAssistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBAssistance.DataLayer.Entities;
using DBAssistance.BussinesLayer.Services.CourseService;
using DBAssistance.BussinesLayer.Dto.Course;
using System.Runtime.CompilerServices;
using AutoMapper;

namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper )
        {
            _courseService = courseService ?? throw new ArgumentNullException( nameof( courseService ) );
            _mapper = mapper ?? throw new ArgumentNullException( nameof( mapper ) );
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            return Ok(_courseService.GetCourses());
        }

        [HttpGet("getshort")]
        public ActionResult<IEnumerable<CourseDto>> GetCoursesDto()
        {
            return Ok(_courseService.GetCoursesDto());
        }

        [HttpGet("id")]
        public ActionResult<CourseDto> GetCourseById(int id)
        {
            return Ok(_courseService.GetCourseByID(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCourse(CourseForCreation course)
        {
            var newCourse = _mapper.Map<Course>(course);

            if (await _courseService.createCourse(newCourse))
                return Ok(_mapper.Map<CourseForCreation>(newCourse));
            else
                return BadRequest();

        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var courseEntity = await _courseService.GetCourseByIdAsync(id);

            if (courseEntity == null) return NotFound();

            var deleteSuccess = await _courseService.DeleteCourse(courseEntity);

            if (deleteSuccess) return NoContent();
            else return BadRequest();
        }
    }
}
