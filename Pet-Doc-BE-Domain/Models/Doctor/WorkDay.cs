namespace Pet_Doc_BE_Domain.Models.Doctor;

public class WorkDay
{
    internal WorkDay(string dayOfWeek, string date, IEnumerable<string> availableSlots)
    {
        Day = dayOfWeek;
        Date = date;
        AvailableSlots = availableSlots;
    }

    public string Day { get; init; }
    public string Date { get; init; }
    public IEnumerable<string> AvailableSlots { get; init; }
}
