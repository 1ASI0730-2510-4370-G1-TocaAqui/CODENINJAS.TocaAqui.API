namespace CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

/// <summary>
///     Unit of Work interface for managing database transactions
/// </summary>
public interface IUnitOfWork
{
    Task<int> CompleteAsync();
} 
