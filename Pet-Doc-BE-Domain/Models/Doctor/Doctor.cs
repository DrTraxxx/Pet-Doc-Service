namespace Pet_Doc_BE_Domain.Models.Doctor;

public class Doctor : Entity<int> , IRoot
{
    internal Doctor(
        string name,
        Speciality specialty,
        Address address,
        HashSet<Appointment> appointments,
        HashSet<Certification> certification,
        HashSet<WorkingDay> schedule)
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
    public HashSet<WorkingDay> Schedule { get; init; }
    public HashSet<Certification> Certification { get; init; }
    public HashSet<Appointment> Appointments { get; init; }
}


