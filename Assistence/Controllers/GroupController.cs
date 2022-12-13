using DBAssistance;
using DBAssistance.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly DBAssistenceContext _dbContext;

        public GroupController(DBAssistenceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Group>> Get()
        {
            return Ok(_dbContext.Group.ToList());

        }
    }
}
