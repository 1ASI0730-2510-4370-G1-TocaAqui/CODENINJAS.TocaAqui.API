namespace CODENINJAS.TocaAqui.API.Payments.Domain.Model.Queries;

/// <summary>
///     Query to get payments by user ID (musician or promoter)
/// </summary>
/// <param name="UserId">User ID</param>
/// <param name="UserRole">User role (musician or promoter)</param>
public record GetPaymentsByUserIdQuery(int UserId, string UserRole); 