using System;
using System.Linq;
using System.Threading.Tasks;
using CODENINJAS.TocaAqui.API.IAM.Application.Internal.OutboundServices;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.IAM.Domain.Services;
using CODENINJAS.TocaAqui.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Http;

namespace CODENINJAS.TocaAqui.API.IAM.Infrastructure.Pipeline.Middleware.Components;

/// <summary>
/// Middleware que valida el Bearer token y carga el <see cref="User"/> en el contexto.
/// </summary>
public sealed class RequestAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public RequestAuthorizationMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(
        HttpContext context,
        ITokenService tokenService,
        IUserQueryService userQueryService)
    {
        // Saltar endpoints con [AllowAnonymous]
        var endpoint = context.GetEndpoint();
        if (endpoint?.Metadata.Any(m => m is AllowAnonymousAttribute) == true)
        {
            await _next(context);
            return;
        }

        try
        {
            // Bearer <token>
            var token = context.Request.Headers.Authorization
                           .FirstOrDefault()?.Split(' ').Last();

            if (string.IsNullOrWhiteSpace(token))
                throw new UnauthorizedAccessException("Token no encontrado");

            var userId = await tokenService.ValidateToken(token);
            if (userId is null)
                throw new UnauthorizedAccessException("Token inválido");

            var user = await userQueryService.Handle(new GetUserByIdQuery(userId.Value));
            if (user is null)
                throw new UnauthorizedAccessException("Usuario inexistente");

            context.Items["User"] = user;
            await _next(context);
        }
        catch (UnauthorizedAccessException)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
}
