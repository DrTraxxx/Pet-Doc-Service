namespace Pet_Doc_BE_Domain.Exceptions;

public sealed class InvalidDoctorException : BaseDomainException
{
	public InvalidDoctorException() { }
	
    public InvalidDoctorException(string message) => Error = message; 
}
