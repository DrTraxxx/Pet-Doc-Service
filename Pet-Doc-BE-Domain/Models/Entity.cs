namespace Pet_Doc_BE_Domain.Models;

public abstract class Entity<Tid> where Tid : struct
{
    public Tid Id { get; private set; } = default;
}


