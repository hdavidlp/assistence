namespace DBAssistance.BussinesLayer.Services.TimetableService.TimetableValidator
{
    public interface IHour24
    {
        string Description { get; }
        bool IsValidTime { get; }
        string TimeProposed { get; }
        string ToMilitaryFormatStr();
        int ToMilitaryFormatInt();
    }
}