
using AutoMapper;
using DBAssistance.BussinesLayer.Dto;
using DBAssistance.BussinesLayer.Services.PeriodService;
using DBAssistance.DataLayer.Entities;

using AutoMapper.QueryableExtensions;
using DBAssistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            _periodService=periodService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Period>> GetPeriods()
        {
            return Ok(_periodService.GetPeriods());
        }

        [HttpGet("adicional")]
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

    }
}
