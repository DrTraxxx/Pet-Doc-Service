namespace Pet_Doc_BE_Domain.Exceptions;

public sealed class InvalidSpecialityException : BaseDomainException
{
	public InvalidSpecialityException(){}
    public InvalidSpecialityException(string message) => Error = message;
}
