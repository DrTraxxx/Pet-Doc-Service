namespace Pet_Doc_BE_Domain.Specifications.Doctors;

public sealed class DoctorByName : Specification<Doctor>
{
    private string _name;

    public DoctorByName(string name) => _name = name;

    public override Expression<Func<Doctor, bool>> ToExpression()
        => doctor => doctor.Name.Equals(_name); 
}
