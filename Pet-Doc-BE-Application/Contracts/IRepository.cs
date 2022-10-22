using Pet_Doc_BE_Domain.Specifications;

namespace Pet_Doc_BE_Application.Contracts;

public interface IRepository<TEntity> 
    where TEntity : IRoot
{
    Task Save(TEntity entity, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TEntity>> Get(Specification<TEntity> specification = default!,
        CancellationToken cancellationToken = default);
    Task<TEntity> Find(Specification<TEntity> specification,
        CancellationToken cancellationToken = default);
    Task<TEntity> Update(Specification<TEntity> specification,
        CancellationToken cancellationToken = default);
}
