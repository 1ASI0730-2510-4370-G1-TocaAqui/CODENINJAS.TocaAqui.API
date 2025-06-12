using CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates;
using MediatR;

namespace CODENINJAS.TocaAqui.API.Profile.Domain.Model.Queries;

public class GetAllProfilesQuery : IRequest<IEnumerable<ProfileDto>>
{
}