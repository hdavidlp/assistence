using DBAssistance;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.BussinesLayer.Services.StudentService;
using DBAssistance.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService )
        {
            _studentService = studentService ?? 
                throw new ArgumentNullException(nameof(studentService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return Ok(_studentService.GetStudents());
        }

        [HttpGet("getshorts")]
        public ActionResult<IEnumerable<StudentDto>> GetStudentsDto()
        {
            return Ok(_studentService.GetStudentsDto());
        }

        [HttpGet("id")]
        public ActionResult<StudentDto> GetStudentDto(int id)
        {
            return Ok(_studentService.GetStudentDto(id));
        }

    }
}
