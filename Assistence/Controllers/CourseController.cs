using DBAssistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBAssistance.DataLayer.Entities;


namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DBAssistenceContext _dbContext;

        public CourseController(DBAssistenceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return Ok(_dbContext.Course.ToList());
        }
    }
}
