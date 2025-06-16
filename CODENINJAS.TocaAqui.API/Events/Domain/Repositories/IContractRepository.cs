using CODENINJAS.TocaAqui.API.Events.Domain.Model.Entities;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Repositories;

/// <summary>
///     Contract repository interface
/// </summary>
public interface IContractRepository : IBaseRepository<Contract>
{
    /// <summary>
    ///     Find a contract by event application id
    /// </summary>
    /// <param name="eventApplicationId">The event application id</param>
    /// <returns>The contract if found, null otherwise</returns>
    Task<Contract?> FindByEventApplicationIdAsync(int eventApplicationId);
} 