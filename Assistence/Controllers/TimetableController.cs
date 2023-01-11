using AutoMapper;
using DBAssistance.BussinesLayer.Dto.Timetable;
using DBAssistance.BussinesLayer.Services.TimetableService;
using DBAssistance.DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly ITimetableService _timetableService;
        private readonly IMapper _mapper;

        public TimetableController(ITimetableService timetableService, IMapper mapper)
        {
            _timetableService = timetableService ??
                throw new ArgumentNullException(nameof(timetableService));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }



        [HttpGet]
        public ActionResult<Timetable> GetTimetable()
        {
            return Ok(_timetableService.GetTimetables());
        }

        [HttpGet("/dto")]
        public ActionResult<IEnumerable<TimetableDto>> GetTimetableDto()
        {
            return Ok(_timetableService.GetTimetableDto());
        }

        [HttpPost]
        public async Task<ActionResult> AddTimetableOption(TimetableForCreation timetable)
        {
            var timeTableEntity = _mapper.Map<Timetable>(timetable);

            var (creationSuccess, info) = await _timetableService.CreateTimetable(timeTableEntity);

            if (!creationSuccess) return BadRequest(info);

            return Ok(timeTableEntity);
        }
    }
}
