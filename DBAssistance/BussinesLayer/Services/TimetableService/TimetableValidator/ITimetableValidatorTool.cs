using DBAssistance.BussinesLayer.Utilities.messenger.MessageMetaData;

namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator
{
    public interface ITimetableValidatorTool
    {
        int KeyIdSuggest { get; }

        //(bool, ICollection<IInformationMetaData>) IsValidPeriodAndTimeTable(IPeriodBetweenHours period);
        Task<(bool, ICollection<IInformationMetaData>)> IsValidPeriodAndTimeTable(IPeriodBetweenHours period);
    }
}