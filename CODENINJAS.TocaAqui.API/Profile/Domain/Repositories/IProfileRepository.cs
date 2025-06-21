using CODENINJAS.TocaAqui.API.Profile.Domain.Model.ValueObjects;

namespace CODENINJAS.TocaAqui.API.Profile.Domain.Repositories;

public interface IProfileRepository
{
    Task<CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile?> GetByIdAsync(int id);
    Task<CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile?> GetByEmailAsync(Email email);
    Task<IEnumerable<CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile>> GetAllAsync();
    Task AddAsync(CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile profile);
    Task UpdateAsync(CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile profile);
    Task<CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile> FindByIdAsync(int id);
    Task SaveAsync(CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile profile);
    Task SaveChangesAsync();
}
