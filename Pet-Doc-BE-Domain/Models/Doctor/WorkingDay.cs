namespace Pet_Doc_BE_Domain.Models.Doctor;

public class WorkingDay : Entity<int>
{
    internal WorkingDay(string dayOfWeek, int dailySlots, string firstSlot)
    {
        DayOfWeek = dayOfWeek;
        DailySlots = dailySlots;
        FirstSlot = firstSlot;
    }

    public string DayOfWeek { get; set; }
    public string FirstSlot { get; set; }
    public int DailySlots { get; set; }
}

