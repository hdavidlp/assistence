using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;

namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator
{
    public interface ITimetableRules
    {
        bool IsValidTimeTable { get; }
        IPeriodBetweenHours PeriodBetweenHours { get; }

        ICollection<IInformationMetaData> Information();
    }
}