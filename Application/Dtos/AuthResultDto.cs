namespace tocaaqui_backend.Application.Dtos
{
    public record AuthResultDto(
    Guid Id,
    string Name,
    string Email,
    string Role,
    string Token);
}
