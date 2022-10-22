namespace Pet_Doc_BE_Domain.Specifications.Doctors;

public class DoctorBySpeciality : Specification<Doctor>
{
    private string _specialty;
    public DoctorBySpeciality(string specialty) => _specialty = specialty;
    public override Expression<Func<Doctor, bool>> ToExpression()
        => doctor => doctor.Specialty.Name.Equals(_specialty);
}
