using AutoMapper;
using DBAssistance;
using DBAssistance.BussinesLayer.Dto.Student;
using DBAssistance.BussinesLayer.Services.StudentService;
using DBAssistance.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper )
        {
            _studentService = studentService ?? 
                throw new ArgumentNullException(nameof(studentService));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
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

        [HttpGet("async/id")]
        public async Task<ActionResult<StudentDto>> GetStudentDtoAsync(int id)
        {
            var studentSelected = await _studentService.GetStudentAsync(id);
            if (studentSelected == null) return NotFound();

            return Ok(studentSelected);
        }

        [HttpPut]
        public async Task<ActionResult<Student>> CreateStudentAsync(StudentForCreationDto student)
        {
            var studentEntity =  _mapper.Map<Student>(student);
            var creationSuccess = await _studentService.CreateStudent(studentEntity);
            if (!creationSuccess)  return BadRequest();
            
            return Ok(studentEntity);
        }
    }
}
