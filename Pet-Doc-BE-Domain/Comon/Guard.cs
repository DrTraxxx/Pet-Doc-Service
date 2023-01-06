namespace Pet_Doc_BE_Domain.Comon;

using Pet_Doc_BE_Domain.Exceptions;

public static class Guard
{
    public static void AgainstModelIncorrectness<TExeption>(params bool[] validationSequence)  
        where TExeption : BaseDomainException ,new()
    {
        var modelValidity = validationSequence.All(x => x);

        if (modelValidity is false)
            throw new TExeption() { Error = "Invalid model state!"};
    }
}
