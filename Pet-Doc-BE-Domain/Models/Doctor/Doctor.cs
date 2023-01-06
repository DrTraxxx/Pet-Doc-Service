namespace Pet_Doc_BE_Domain.Models.Doctor;

using Pet_Doc_BE_Domain.Exceptions;
using Pet_Doc_BE_Domain.Extensions;

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
        Guard.AgainstModelIncorrectness<InvalidDoctorException>
            (name.Validate(ForEmptyString, ForStringLength),
             specialty.Validate(ForInvalidObjectState),
             address.Validate(ForInvalidObjectState),
             schedule.Validate(ForInvalidObjectState)
            );

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

    public IEnumerable<string> GetAppointmentHours()
    {
        foreach (int slotIndex in Enumerable.Range(0, Schedule.DailySlots))
            yield return TimeOnly.Parse(Schedule.FirstSlot).AddHours(slotIndex).ToString("HH:mm");
    } 

    public void AddAppointment(Appointment appointment)
    {
        Guard.AgainstModelIncorrectness<InvalidAppointmentException>
            (appointment.Validate(ForInvalidObjectState));

        Appointments.Add(appointment);
    }

    public void CancelAppointment(Appointment appointment)
        => Appointments.RemoveWhere(a => a.Id == appointment.Id);




}


