namespace api_templatodo.ViewModels;

public class TodoToday
{

    public TodoToday(string activity, string description, int durationInMinutes, string timeOfDay, string note)
    {
        Activity = activity;
        Description = description;
        DurationInMinutes = durationInMinutes;
        TimeOfDay = timeOfDay;
        Note = note;
    }

    public string Activity { get; }
    public string Description { get; }
    public int DurationInMinutes { get; }
    public string TimeOfDay { get; }
    public string Note { get; }
}