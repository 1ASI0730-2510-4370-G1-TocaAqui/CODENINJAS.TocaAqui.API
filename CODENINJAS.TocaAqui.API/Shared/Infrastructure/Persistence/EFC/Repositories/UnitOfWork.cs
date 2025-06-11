using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Unit of Work implementation for managing database transactions
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
} 
