using MediatR;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUserFeatures;

public class GetUserFeaturesQuery : IRequest<List<UserFeaturesDto>>
{
    public Guid UserId { get; set; }
}