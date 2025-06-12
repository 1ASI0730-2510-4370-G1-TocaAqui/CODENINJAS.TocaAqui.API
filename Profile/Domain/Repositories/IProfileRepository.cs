using tocaaqui_backend.Profile.Domain.Model.ValueObjects;

namespace tocaaqui_backend.Profile.Domain.Repositories;

public interface IProfileRepository
{
    Task<Model.Aggregates.Profile?> GetByIdAsync(ProfileId id);
    Task<Model.Aggregates.Profile?> GetByEmailAsync(Email email);
    Task<IEnumerable<Model.Aggregates.Profile>> GetAllAsync();
    Task AddAsync(Model.Aggregates.Profile profile);
    Task UpdateAsync(Model.Aggregates.Profile profile);
    Task<Model.Aggregates.Profile> FindByIdAsync(Guid id);
    Task SaveAsync(Model.Aggregates.Profile profile);
    Task SaveChangesAsync();
}
