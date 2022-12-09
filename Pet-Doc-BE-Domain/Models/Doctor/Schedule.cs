namespace Pet_Doc_BE_Domain.Models.Doctor;

public class Schedule
{
    internal Schedule(int dailySlots,string firstSlot,string lastSlot , int numberOfWorkingDays)
    {
        DailySlots = dailySlots;
        FirstSlot = firstSlot;
        LastSlot = lastSlot;
        NumberOfWorkingDays = numberOfWorkingDays;
    }

    public string FirstSlot { get; init; }
    public string LastSlot { get; init; }
    public int NumberOfWorkingDays { get;init; }
    public int DailySlots { get; init; }

}

