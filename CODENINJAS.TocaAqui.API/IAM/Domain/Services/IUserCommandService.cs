using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Commands;

namespace CODENINJAS.TocaAqui.API.IAM.Domain.Services;

/// <summary>Orquesta comandos sobre <see cref="User"/> (alta y autenticación).</summary>
public interface IUserCommandService
{
    /// <summary>Registra un nuevo usuario.</summary>
    Task Handle(SignUpCommand command);

    /// <summary>Inicia sesión y devuelve el usuario + JWT.</summary>
    Task<(User user, string token)> Handle(SignInCommand command);
}
