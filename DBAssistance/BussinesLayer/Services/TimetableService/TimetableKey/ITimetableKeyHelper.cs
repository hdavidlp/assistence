using DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator;

namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableKeySuggest
{
    public interface ITimetableKeyHelper
    {
        ITimetableRules PeriodValidator { get; }
        int keySuggest();
    }
}