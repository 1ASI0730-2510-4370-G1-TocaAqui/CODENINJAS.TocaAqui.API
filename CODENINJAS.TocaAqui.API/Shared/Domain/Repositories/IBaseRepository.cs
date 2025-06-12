namespace CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

/// <summary>
///     Base repository interface for all domain entities
/// </summary>
/// <typeparam name="TEntity">The entity type</typeparam>
public interface IBaseRepository<TEntity>
{
    Task<IEnumerable<TEntity>> ListAsync();
    Task AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    void Update(TEntity entity);
    void Remove(TEntity entity);
} 
