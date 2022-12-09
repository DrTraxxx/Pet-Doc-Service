namespace Pet_Doc_BE_Domain.Models.Doctor;

using Pet_Doc_BE_Domain.Models.Doctor.WorkCalendar;

public sealed class Doctor : Entity<int> , IRoot
{
    internal Doctor(
        string name,
        Speciality specialty,
        Address address,
        HashSet<Appointment> appointments,
        HashSet<Certification> certification,
        Schedule schedule)
    {
        Name = name;
        Specialty = specialty;
        Address = address;
        Appointments = appointments;
        Certification = certification;
        Schedule = schedule;
    }

    /*EF Core workaround for navigational props*/
    private Doctor(string name)
    {
        Name=name;
        Specialty = default!;
        Address = default!;
        Appointments = default!;
        Certification = default!;
        Schedule = default!;
    }

    public string Name { get; init; }
    public Speciality Specialty { get; init; }
    public Address Address { get; init; } 
    public Schedule Schedule { get; init; }
    public HashSet<Certification> Certification { get; init; }
    public HashSet<Appointment> Appointments { get; init; }

    public Calendar GetDoctorCalendar(DateTime startDate)
    {
        var test = GetMontlySchedule(startDate);

        return default;
    }

    public IEnumerable<string> GetDaylySlots()
    {
        foreach (int slotIndex in Enumerable.Range(0, Schedule.DailySlots))
            yield return TimeOnly.Parse(Schedule.FirstSlot).AddHours(slotIndex).ToString("HH:mm");

    }


    private IEnumerable<WorkDay> GetMontlySchedule(DateTime fromDate)
    {
        foreach (int indx in Enumerable.Range(1,30))
        {
            var date = fromDate.AddDays(indx);

            if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday) continue;

            var scheduleSlots = GetDaylySlots();
           
            var daylislots = scheduleSlots
                .Except(Appointments
                    .Where(x => x.AppointmentDate.Date.Equals(date.Date))
                    .Select(x => x.Slot));

            yield return new(date.DayOfWeek.ToString(),date.Date.ToString(),daylislots);

        }
    }

    private WorkDay GetToday(DateTime startDate)
    {

        if (startDate.Date == DateTime.Today) return default!;

        return default!;
    }
}


