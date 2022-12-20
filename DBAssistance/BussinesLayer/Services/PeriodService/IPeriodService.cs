using DBAssistance.BussinesLayer.Dto;
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