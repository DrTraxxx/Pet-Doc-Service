namespace Pet_Doc_BE_Domain.Models.Doctor.WorkCalendar;

public class Calendar
{
    internal Calendar(WorkDay today, IEnumerable<WorkDay> montlySchadule)
    {
        Today = today;
        MontlySchadule = montlySchadule;
    }

    public WorkDay Today { get; init;}
    public IEnumerable<WorkDay> MontlySchadule { get; set; }
}

