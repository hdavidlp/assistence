using DBAssistance.BussinesLayer.Dto.Timetable;
using DBAssistance.BussinesLayer.Utilities.messenger;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.TimetableService
{
    public interface ITimetableService
    {
        IEnumerable<Timetable> GetTimetables();
        IEnumerable<TimetableDto> GetTimetableDto();
        Task<(bool, IInformationMetaData)> CreateTimetable(Timetable timetable);
    }
}