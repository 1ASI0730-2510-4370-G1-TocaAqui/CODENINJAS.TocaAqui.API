using CODENINJAS.TocaAqui.API.Events.Domain.Model.Entities;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Events.Domain.Repositories;

/// <summary>
///     RiderTechnical repository interface
/// </summary>
public interface IRiderTechnicalRepository : IBaseRepository<RiderTechnical>
{
    /// <summary>
    ///     Find a rider technical by event application id
    /// </summary>
    /// <param name="eventApplicationId">The event application id</param>
    /// <returns>The rider technical if found, null otherwise</returns>
    Task<RiderTechnical?> FindByEventApplicationIdAsync(int eventApplicationId);
} 