using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Queries;

namespace CODENINJAS.TocaAqui.API.IAM.Domain.Services;

/// <summary>Resuelve consultas de usuarios.</summary>
public interface IUserQueryService
{
    Task<User?>            Handle(GetUserByIdQuery    query);
    Task<IEnumerable<User>>Handle(GetAllUsersQuery    query);
    Task<User?>            Handle(GetUserByEmailQuery query);
}
