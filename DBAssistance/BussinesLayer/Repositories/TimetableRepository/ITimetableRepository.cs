using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.TimetableRepository
{
    public interface ITimetableRepository
    {
        Task<bool> CreateTimeTableAsync(Timetable timetable);
        IEnumerable<Timetable> GetTimetable();
        Task<bool> SaveChangesAsync();
        Task<bool> TimetableKeyExistAsync(int key);
    }
}