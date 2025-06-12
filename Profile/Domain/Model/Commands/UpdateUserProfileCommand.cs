using MediatR;

namespace tocaaqui_backend.Profile.Domain.Model.Commands;

public record UpdateUserProfileCommand(Guid Id, string Name, string Email, string Genre, string Type, string Description) : IRequest<bool>;
