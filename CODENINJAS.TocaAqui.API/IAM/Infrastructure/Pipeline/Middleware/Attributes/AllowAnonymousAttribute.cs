using System;

namespace CODENINJAS.TocaAqui.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;

/// <summary>
/// Marca un endpoint como público; salta la validación de token.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class AllowAnonymousAttribute : Attribute
{
}
