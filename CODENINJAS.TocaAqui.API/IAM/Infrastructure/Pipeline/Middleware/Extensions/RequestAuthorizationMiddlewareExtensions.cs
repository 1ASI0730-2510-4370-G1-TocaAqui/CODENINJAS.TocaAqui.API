using Microsoft.AspNetCore.Builder;

namespace CODENINJAS.TocaAqui.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;

/// <summary>
/// Helper para registrar el middleware en Program.cs.
/// </summary>
public static class RequestAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder app) =>
        app.UseMiddleware<Middleware.Components.RequestAuthorizationMiddleware>();
}
