namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator
{
    public interface IPeriodBetweenHours
    {
        IHour24 EndTime { get; }
        IHour24 StartTime { get; }
        bool IsStartTimeBeforeEndTime();
        int MilitaryFormat();
    }
}