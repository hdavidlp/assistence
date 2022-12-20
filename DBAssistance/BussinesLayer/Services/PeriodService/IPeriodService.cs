using DBAssistance.BussinesLayer.Dto;
using DBAssistance.DataLayer.Entities;

namespace DBAssistance.BussinesLayer.Services.PeriodService
{
    public interface IPeriodService
    {
        IEnumerable<Period> Get();
        IEnumerable<PeriodDto> extra();
    }
}