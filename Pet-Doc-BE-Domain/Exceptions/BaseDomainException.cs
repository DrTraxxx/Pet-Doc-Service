namespace Pet_Doc_BE_Domain.Exceptions;

public abstract class BaseDomainException : Exception
{
    private string? _errorMessage;

    public string Error { get => _errorMessage ?? base.Message; set => _errorMessage = value;}
}
