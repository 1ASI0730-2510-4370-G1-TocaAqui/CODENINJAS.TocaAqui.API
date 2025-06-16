using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Queries;
using CODENINJAS.TocaAqui.API.IAM.Domain.Repositories;
using CODENINJAS.TocaAqui.API.IAM.Domain.Services;

namespace CODENINJAS.TocaAqui.API.IAM.Application.Internal.QueryServices;

/// <summary>Resuelve consultas de usuario contra el repositorio.</summary>
public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)    => await userRepository.FindByIdAsync(query.Id);

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query) =>
        await userRepository.ListAsync();

    public async Task<User?> Handle(GetUserByEmailQuery query) =>
        await userRepository.FindByEmailAsync(query.Email);
}
