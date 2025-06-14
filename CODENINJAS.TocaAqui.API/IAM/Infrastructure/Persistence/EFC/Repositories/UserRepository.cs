using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.IAM.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CODENINJAS.TocaAqui.API.IAM.Infrastructure.Persistence.EFC.Repositories;

/// <inheritdoc />
public class UserRepository(AppDbContext context)
    : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByEmailAsync(string email) =>
        await Context.Set<User>()
                     .AsNoTracking()
                     .FirstOrDefaultAsync(u => u.Email == email);

    public bool ExistsByEmail(string email) =>
        Context.Set<User>().Any(u => u.Email == email);
}
