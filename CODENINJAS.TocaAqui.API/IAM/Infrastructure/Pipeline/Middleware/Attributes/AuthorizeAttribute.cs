using System;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CODENINJAS.TocaAqui.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;

/// <summary>
/// Exige autenticación JWT para acceder al endpoint.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Si la acción permite anónimo no hacemos nada
        if (context.ActionDescriptor.EndpointMetadata
                .Any(m => m is AllowAnonymousAttribute)) return;

        // El middleware RequestAuthorizationMiddleware meterá el User aquí
        var user = context.HttpContext.Items["User"] as User;
        if (user is null) context.Result = new UnauthorizedResult();
    }
}
