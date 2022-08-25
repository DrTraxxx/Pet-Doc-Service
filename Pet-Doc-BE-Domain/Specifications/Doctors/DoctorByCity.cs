namespace Pet_Doc_BE_Domain.Specifications.Doctors; 

public class DoctorByCity : Specification<Doctor>
{
    private string _city;

    public DoctorByCity(string city) => _city = city;

    public override System.Linq.Expressions.Expression<Func<Doctor, bool>> ToExpression() 
        => doctor => doctor.Address.City.Equals(_city);
}
