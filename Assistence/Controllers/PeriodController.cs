using DBAssistance;
using DBAssistance.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private readonly DBAssistenceContext _dbContext;

        public PeriodController(DBAssistenceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Period>> Get()
        {
            return Ok(_dbContext.Period.ToList());
        }

        
    }
}
