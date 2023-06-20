using MediatR;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUserFeatures;

public class GetUserFeaturesQuery : IRequest<UserFeaturesListVm>
{
    public Guid UserId { get; set; }
}
