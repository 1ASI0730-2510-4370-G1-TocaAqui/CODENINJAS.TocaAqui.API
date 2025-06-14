using CODENINJAS.TocaAqui.API.IAM.Application.Internal.OutboundServices;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Commands;
using CODENINJAS.TocaAqui.API.IAM.Domain.Repositories;
using CODENINJAS.TocaAqui.API.IAM.Domain.Services;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.IAM.Application.Internal.CommandServices;

/// <summary>
///     Maneja los comandos Sign-Up y Sign-In para <see cref="User"/>.
/// </summary>
public class UserCommandService(
    IUserRepository  userRepository,
    ITokenService    tokenService,
    IHashingService  hashingService,
    IUnitOfWork      unitOfWork)
    : IUserCommandService
{
    // ---------------------- Sign-Up ----------------------
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByEmail(command.Email))
            throw new InvalidOperationException($"El correo {command.Email} ya está registrado.");

        var hash = hashingService.HashPassword(command.Password);

        var user = new User(
            command.Name,
            command.Email,
            hash,
            command.Role,
            command.Genre,
            command.Type,
            command.Description,
            command.ImageUrl);

        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
    }

    // ---------------------- Sign-In ----------------------
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByEmailAsync(command.Email)
                   ?? throw new InvalidOperationException("Credenciales inválidas.");

        if (!hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new InvalidOperationException("Credenciales inválidas.");

        var token = tokenService.GenerateToken(user);
        return (user, token);
    }
}
