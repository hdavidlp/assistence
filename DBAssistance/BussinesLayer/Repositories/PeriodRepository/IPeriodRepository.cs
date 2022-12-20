using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.PeriodRepository
{
    public interface IPeriodRepository
    {
        IEnumerable<Period> GetPeriods();
        Period GetPeriod(int periodId);
    }
}