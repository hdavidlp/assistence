using AutoMapper;
using DBAssistance.BussinesLayer.Dto.Timetable;
using DBAssistance.BussinesLayer.Repositories.TimetableRepository;
using DBAssistance.BussinesLayer.Utilities.messenger.TimetableMessages;
using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;
using DBAssistance.BussinesLayer.Services.TimetableService.TimetableKeySuggest;
using DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator;
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
        private readonly ITimetableValidatorTool _timetableValidatorTool;
        private readonly IMapper _mapper;
        private ICollection<IInformationMetaData> _infoOperation = new List<IInformationMetaData>();

        public TimetableService(
            ITimetableRepository timetableRepository, 
            IMapper mapper,
            ITimetableValidatorTool timetableValidatorTool)
        {
            _timetableRepository = timetableRepository ??
                throw new ArgumentNullException(nameof(timetableRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
            _timetableValidatorTool = timetableValidatorTool ??
                throw new ArgumentNullException(nameof(timetableValidatorTool));
        }

        private ICollection<IInformationMetaData> addInfoOperation(
            IInformationMetaData message)
        {
            _infoOperation.Add(message);
            return _infoOperation;
        }

        private IPeriodBetweenHours TimeTableDtoToPeriod(TimetableDto timetable)
        {
            return new PeriodBetweenHours(
                        new Hour24(timetable.startTime),
                        new Hour24(timetable.endTime));

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
            var (isValid, _infoOperation) = await _timetableValidatorTool
                .IsValidPeriodAndTimeTable(TimeTableDtoToPeriod(
                    _mapper.Map<TimetableDto>(timetable)));

            if (!isValid) return (false, _infoOperation);

            timetable.keyId = _timetableValidatorTool.KeyIdSuggest;

            var creationSuccess = await _timetableRepository.CreateTimeTableAsync(timetable);

            if(!creationSuccess) return (false, addInfoOperation(new CreationNotSuccess()));

            return (true, addInfoOperation( new CreationSuccess()));
        }

        public async Task<(bool, ICollection<IInformationMetaData>)> UpdateTimetable(
            int id, TimetableForUpdateDto timetable)
        {
            var (isValid, _infoOperation) = await _timetableValidatorTool
                .IsValidPeriodAndTimeTable(TimeTableDtoToPeriod(
                    _mapper.Map<TimetableDto>(timetable)));

            if (!isValid) return (false, _infoOperation);

            var selectedTimetable = await _timetableRepository.GetTimetableAsync(id);
            _mapper.Map(timetable, selectedTimetable);

            selectedTimetable.keyId = _timetableValidatorTool.KeyIdSuggest;
            var updateSuccess= await _timetableRepository.UpdateTimetable();

            if (!updateSuccess) 
                return (false, addInfoOperation(new UpdateNotComplete()));

            return (true, addInfoOperation(new UpdateSuccess()));
        }
    }
}
