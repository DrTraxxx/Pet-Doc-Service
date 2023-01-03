namespace Pet_Doc_BE_Domain.Models.Doctor;

using Pet_Doc_BE_Domain.Comon.Validations;
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
        ValidateModel(name, specialty, address, schedule);

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

    public void ValidateModel(string name , Speciality specialty, Address address, Schedule schedule)
    {
        var isNameValid = name.Validate(Validate.ForEmptyString,Validate.ForStringLength);
        var isSpecialtyValid = specialty.Validate(Validate.ForInvalidObjectState);
        var isAddressValid = address.Validate(Validate.ForInvalidObjectState);
        var isScheduleValid = schedule.Validate(Validate.ForInvalidObjectState);

        if (!isNameValid || !isSpecialtyValid || !isAddressValid || !isScheduleValid)
            throw  new InvalidDoctorException("Invalid state detected when building model!");
    }
}


