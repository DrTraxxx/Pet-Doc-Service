namespace Pet_Doc_BE_Domain.Specifications.Appointments;

public class PatientsAppointments : Specification<Appointment>
{
    private string _patientId;

    public PatientsAppointments(string patientId) => _patientId = patientId;

    public override Expression<Func<Appointment, bool>> ToExpression()
    {
        throw new NotImplementedException();
    }
}
