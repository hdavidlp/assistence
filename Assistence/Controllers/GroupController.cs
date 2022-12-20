using DBAssistance;
using DBAssistance.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return Ok(_dbContext.Group.Include(p => p.Period).ToList());
        }
    }
}
