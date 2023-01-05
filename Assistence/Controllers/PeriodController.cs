
using AutoMapper;
using DBAssistance.BussinesLayer.Services.PeriodService;
using DBAssistance.DataLayer.Entities;

using AutoMapper.QueryableExtensions;
using DBAssistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBAssistance.BussinesLayer.Dto.Period;

namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private readonly IPeriodService _periodService;
        private readonly IMapper _mapper;

        public PeriodController(IPeriodService periodService, IMapper mapper)
        {
            _periodService=periodService ?? throw new ArgumentNullException(nameof(periodService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)) ;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Period>> GetPeriods()
        {
            return Ok(_periodService.GetPeriods());
        }

        [HttpGet("getshort")]
        public ActionResult<IEnumerable<PeriodDto>> GetPeriodsShort()
        {
            var res = _periodService.GetPeriodsShortInfo();
            return Ok(res);
        }

        [HttpGet("id")]
        public ActionResult<PeriodDto> GetPeriod(int id)
        {
            return Ok(_periodService.GetPeriod(id));
        }

        [HttpPost]
        public async Task<ActionResult<PeriodForCreation>> CreatePeriod(PeriodForCreation period)
        {
            var newPeriod = _mapper.Map<Period>(period);

            if(await _periodService.AddPeriod(newPeriod))
                return Ok(_mapper.Map<PeriodForCreation>(newPeriod));
            return BadRequest();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeletePeriod(int id)
        {
            var periodEntity = await _periodService.GetPeriodAsync(id);

            if (periodEntity == null) return NotFound();

            bool deleteSuccess = await _periodService.DeletePeriod(periodEntity);

            if (deleteSuccess) return NoContent();
            else return BadRequest();

        }

    }
}
