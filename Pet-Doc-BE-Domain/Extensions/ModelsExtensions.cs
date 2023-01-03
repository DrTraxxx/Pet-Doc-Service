namespace Pet_Doc_BE_Domain.Extensions;

public static class ModelsExtensions
{
    public static bool Validate<TInput>(this TInput input, params Func<TInput, bool>[] validations)
        => validations.All(x => x(input));
}
