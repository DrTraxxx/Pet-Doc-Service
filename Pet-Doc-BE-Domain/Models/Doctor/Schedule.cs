namespace Pet_Doc_BE_Domain.Models.Doctor;

public class Schedule
{
    internal Schedule(string staringDay, int dailySlots, string firstSlot , int numberOfWorkingDays)
    {
        StaringDay = staringDay;
        DailySlots = dailySlots;
        FirstSlot = firstSlot;
        NumberOfWorkingDays = numberOfWorkingDays;
    }

    public string StaringDay { get; init; }
    public string FirstSlot { get; init; }
    public int NumberOfWorkingDays { get;init; }
    public int DailySlots { get; init; }
}

