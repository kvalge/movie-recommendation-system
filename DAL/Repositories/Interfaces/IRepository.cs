using Domain.Identifiers;

namespace DAL.Repositories.Interfaces;

public interface IRepository<TEntity> : IRepository<TEntity, int>
    where TEntity : IDomainId
{
}

public interface IRepository<TEntity, TKey>
    where TEntity : IDomainId<TKey>
    where TKey : IEquatable<TKey>
{
    IEnumerable<TEntity> All(TKey? userId = default!);
    Task<IEnumerable<TEntity>> AllAsync(TKey? userId = default!);

    TEntity? Find(TKey id, TKey? userId = default!);
    Task<TEntity?> FindAsync(TKey id, TKey? userId = default!);

    void Add(TEntity entity, TKey? userId = default!);

    TEntity Update(TEntity entity, TKey? userId = default!);

    void Remove(TEntity entity, TKey? userId = default!);

    void Remove(TKey id, TKey? userId = default!);
    Task RemoveAsync(TKey id, TKey? userId = default!);

    bool Exists(TKey id, TKey? userId = default!);
    Task<bool> ExistsAsync(TKey id, TKey? userId = default!);
}