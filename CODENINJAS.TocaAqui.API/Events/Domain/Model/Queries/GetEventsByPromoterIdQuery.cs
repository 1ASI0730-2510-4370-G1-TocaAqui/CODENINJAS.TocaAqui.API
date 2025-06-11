namespace CODENINJAS.TocaAqui.API.Events.Domain.Model.Queries;

/// <summary>
///     Query to get all events created by a specific promoter
/// </summary>
/// <param name="PromoterId">The promoter ID</param>
public record GetEventsByPromoterIdQuery(int PromoterId); 
