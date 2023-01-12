using DBAssistance.BussinesLayer.Dto.Timetable;
using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.TimetableService
{
    public interface ITimetableService
    {
        IEnumerable<Timetable> GetTimetables();
        IEnumerable<TimetableDto> GetTimetableDto();
        Task<(bool, ICollection<IInformationMetaData>)> CreateTimetable(Timetable timetable);
        Task<(bool, ICollection<IInformationMetaData>)> UpdateTimetable(int id, TimetableForUpdateDto timetable);
    }
}