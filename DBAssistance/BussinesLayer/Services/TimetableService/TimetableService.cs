using AutoMapper;
using DBAssistance.BussinesLayer.Dto.Timetable;
using DBAssistance.BussinesLayer.Repositories.TimetableRepository;
using DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages;
using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;
using DBAssistance.BussinesLayer.Services.TimetableService.TimetableKeySuggest;
using DBAssistance.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator;

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

        public async Task<(bool, ICollection<IInformationMetaData>)> CreateTimetable (Timetable timetable)
        {
            ITimetableKeyHelper timetableKeyHelper =
                new TimetableKeyHelper(
                    new PeriodBetweenHours(
                        new Hour24(timetable.startTime),
                        new Hour24(timetable.endTime)));

            if (!timetableKeyHelper.PeriodValidator.IsValidTimeTable)
                return (false, timetableKeyHelper.PeriodValidator.Information());

            timetable.keyId = timetableKeyHelper.keySuggest();

            if (await _timetableRepository.TimetableKeyExistAsync(timetable.keyId))
                return (false, new KeyIdExistMessage[0]);
                

            return (await _timetableRepository.CreateTimeTableAsync(timetable),
                new TimetableCreatedMessage[0]);
        }

        public async Task<(bool, ICollection<IInformationMetaData>)> UpdateTimetable(
            int id, TimetableForUpdateDto timetable)
        {
            ITimetableKeyHelper timetableKeyHelper =
                new TimetableKeyHelper(
                    new PeriodBetweenHours(
                        new Hour24(timetable.startTime),
                        new Hour24(timetable.endTime)));

            if (!timetableKeyHelper.PeriodValidator.IsValidTimeTable)
                return (false, timetableKeyHelper.PeriodValidator.Information());

            int keyId = timetableKeyHelper.keySuggest();

            if (await _timetableRepository.TimetableKeyExistAsync(keyId))
                return (false, new KeyIdExistMessage[0]);

            var selectedTimetable = await _timetableRepository.GetTimetableAsync(id);
            _mapper.Map(timetable, selectedTimetable);

            selectedTimetable.keyId = keyId;
            var updateSuccess= await _timetableRepository.UpdateTimetable();

            if (!updateSuccess) return (false, new UpdateNotComplete[0]);

            return (true, new UpdateSuccess[0]);
        }
    }
}
