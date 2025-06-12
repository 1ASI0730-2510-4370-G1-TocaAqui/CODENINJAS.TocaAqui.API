using MediatR;
using tocaaqui_backend.Profile.Domain.Model.Aggregates;

namespace tocaaqui_backend.Profile.Domain.Model.Queries;

public class GetAllProfilesQuery : IRequest<IEnumerable<ProfileDto>>
{
}