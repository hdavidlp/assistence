using DBAssistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBAssistance.DataLayer.Entities;
using DBAssistance.BussinesLayer.Services.CourseService;
using DBAssistance.BussinesLayer.Dto;

namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService )
        {
            _courseService = courseService ?? throw new ArgumentNullException( nameof( courseService ) );
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
    }
}
