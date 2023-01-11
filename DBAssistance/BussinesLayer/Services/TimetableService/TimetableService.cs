using AutoMapper;
using DBAssistance.BussinesLayer.Dto.Timetable;
using DBAssistance.BussinesLayer.Repositories.TimetableRepository;
using DBAssistance.BussinesLayer.Utilities.messenger;
using DBAssistance.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssistance.BussinesLayer.Services.TimetableService
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _timetableRepository;
        private readonly IMapper _mapper;

        public TimetableService(ITimetableRepository timetableRepository, IMapper mapper )
        {
            _timetableRepository = timetableRepository ??
                throw new ArgumentNullException(nameof(timetableRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<Timetable> GetTimetables()
        {
            return _timetableRepository.GetTimetable();
        }

        public IEnumerable<TimetableDto> GetTimetableDto()
        {
            var timetableEntity = _timetableRepository.GetTimetable();

            timetableEntity.OrderBy(t => t.keyId);

            IEnumerable<TimetableDto> timetable = 
                _mapper.Map<IEnumerable<TimetableDto>>(timetableEntity);

            timetable.ToList().ForEach
                (t => t.longDescription = t.startTime + " - " + t.endTime);

            return timetable;
        }

        public async Task<(bool, IInformationMetaData)> CreateTimetable (Timetable timetable)
        {
            KeyBuilderForTimeTable keyManagement = 
                new KeyBuilderForTimeTable(timetable.startTime, timetable.endTime);

            if (!keyManagement.IsValidStarTime) 
                return (false, new InvalidTimeMessage(keyManagement.StartTime));
            if (!keyManagement.IsValidTimeTable) 
                return (false, new InvalidTimeMessage(keyManagement.EndTime));

            timetable.keyId = keyManagement.keySuggest;

            if (await _timetableRepository.TimetableKeyExistAsync(timetable.keyId))
                return (false, new KeyIdExistMessage());

            return (await _timetableRepository.CreateTimeTableAsync(timetable),
                new TimetableCreatedMessage());
        }
    }
}
