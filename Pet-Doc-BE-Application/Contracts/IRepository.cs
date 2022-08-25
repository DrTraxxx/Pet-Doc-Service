namespace Pet_Doc_BE_Application.Contracts;

public interface IRepository<in TEntity> 
    where TEntity : IRoot
{
    Task Save(TEntity entity, CancellationToken cancellationToken = default);
}
