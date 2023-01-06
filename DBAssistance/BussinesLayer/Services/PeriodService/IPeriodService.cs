using DBAssistance.BussinesLayer.Dto.Period;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.PeriodService
{
    public interface IPeriodService
    {
        IEnumerable<Period> GetPeriods();
        IEnumerable<PeriodDto> GetPeriodsShortInfo();
        PeriodDto GetPeriod(int periodId);
        Task<bool> AddPeriod(Period period);
        Task<Period> GetPeriodAsync(int id);
        Task<bool> DeletePeriod(Period period);
        Task<bool> UpdatePeriod(int id, PeriodForUpdateDto period);
    }
}