namespace Pet_Doc_BE_Domain.Models.Doctor;

public class Appointment : Entity<int>
{
    internal Appointment(DateTime appDate,string slot)
    {
        AppointmentDate = appDate;
        Slot = slot;
    }

    private Appointment()
    {
        AppointmentDate = default!;
        Slot = default!;
    }

    public DateTime AppointmentDate { get; set; }
    public string Slot { get; set; }
}
