namespace CODENINJAS.TocaAqui.API.IAM.Domain.Model.Queries;

/// <summary>Consulta un usuario por su correo (email es el “username”).</summary>
public record GetUserByEmailQuery(string Email);
