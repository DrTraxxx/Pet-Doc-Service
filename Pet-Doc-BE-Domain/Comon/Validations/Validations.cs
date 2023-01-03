namespace Pet_Doc_BE_Domain.Comon.Validations;

public sealed class Validate 
{
    public static Func<string, bool> ForEmptyString = value => string.IsNullOrEmpty(value);

    public static Func<string,bool> ForStringLength = value => MinNameLength <= value.Length && value.Length <= MaxNameLength;

    public static Func<int ,bool> AgainstOutOfRange = value => MinWorkDays <= value && value <= MaxWorkDays;

    public static Func<object, bool> ForInvalidObjectState = value => value == default;

}

