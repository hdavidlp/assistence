using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Repositories.PeriodRepository
{
    public interface IPeriodRepository
    {
        IEnumerable<DataLayer.Entities.Period> Get();
    }
}