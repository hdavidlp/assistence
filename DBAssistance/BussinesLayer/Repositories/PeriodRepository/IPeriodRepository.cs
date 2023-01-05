using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.PeriodRepository
{
    public interface IPeriodRepository
    {
        IEnumerable<Period> GetPeriods();
        Task<Period> GetPeriodAsync(int periodId);
        Task<bool> AddPeriod(Period period);
        Task<bool> DeletePeriod(Period period);
    }
}