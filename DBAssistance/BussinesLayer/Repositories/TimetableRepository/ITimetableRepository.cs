using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.TimetableRepository
{
    public interface ITimetableRepository
    {
        Task<bool> CreateTimeTableAsync(Timetable timetable);
        IEnumerable<Timetable> GetTimetable();
        Task<Timetable> GetTimetableAsync(int id);
        Task<bool> SaveChangesAsync();
        Task<bool> TimetableKeyExistAsync(int key);
        Task<bool> UpdateTimetable();
    }
}