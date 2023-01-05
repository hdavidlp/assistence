using DBAssistance.BussinesLayer.Dto.Period;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.PeriodService
{
    public interface IPeriodService
    {
        IEnumerable<Period> GetPeriods();
        IEnumerable<PeriodDto> GetPeriodsShortInfo();
        PeriodDto GetPeriod(int periodId);
    }
}