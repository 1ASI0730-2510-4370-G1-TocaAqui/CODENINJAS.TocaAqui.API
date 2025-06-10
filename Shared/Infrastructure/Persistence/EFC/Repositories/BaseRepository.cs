using Microsoft.EntityFrameworkCore;
using tocaaqui_backend.Shared.Domain.Repositories;
using tocaaqui_backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace tocaaqui_backend.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Base repository implementation for all domain entities
/// </summary>
/// <typeparam name="TEntity">The entity type</typeparam>
public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context;

    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task<IEnumerable<TEntity>> ListAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<TEntity?> FindByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
} 
