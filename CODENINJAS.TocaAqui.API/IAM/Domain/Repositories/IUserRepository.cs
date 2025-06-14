using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.IAM.Domain.Repositories;

/// <summary>Contrato de persistencia para <see cref="User"/>.</summary>
public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync(string email);
    bool        ExistsByEmail(string email);
}
