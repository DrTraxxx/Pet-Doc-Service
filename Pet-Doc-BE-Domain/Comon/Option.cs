namespace Pet_Doc_BE_Domain.Comon;

public abstract class Option<T>
{
    public Option(T value) => Value = value; 

    private Option() { }

    public T Value { get; init;}

    //public Option<TResult> Bind<TResult>(Func<T, Option<TResult>> func)
    //    => Value is not null ? func(Value) : Option<TResult>.None;

}


