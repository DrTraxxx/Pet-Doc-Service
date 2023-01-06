namespace Pet_Doc_BE_Domain.Models;

using Pet_Doc_BE_Domain.Specifications.Doctors;

public sealed class ModelConstants
{
    public sealed class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 50;
        public const int MinWorkDays = 1;
        public const int MaxWorkDays = 7;
        public const int MinEmailLength = 3;
        public const int MaxEmailLength = 50;
        public const int MaxUrlLength = 2048;
    }

    public sealed class Validate
    {
        public static Func<string, bool> ForEmptyString = value => string.IsNullOrEmpty(value);

        public static Func<string, bool> ForStringLength = value => MinNameLength <= value.Length && value.Length <= MaxNameLength;

        public static Func<int, bool> AgainstOutOfRange = value => MinWorkDays <= value && value <= MaxWorkDays;

        public static Func<object, bool> ForInvalidObjectState = value => value == default;

    } 
}
