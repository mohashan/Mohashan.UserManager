using MediatR;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUserDetails;

public class GetUserDetailQuery : IRequest<UserDetailVm>
{
    public Guid Id { get; set; }
}