namespace tocaaqui_backend.Application.Commands;

using MediatR;

public record LogoutCommand(Guid UserId) : IRequest<Unit>;
