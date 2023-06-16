using MediatR;

namespace Mohashan.UserManager.Application.Features.Users;

public class GetUserDetailQuery : IRequest<UserDetailVm>
{
    public Guid Id { get; set; }
}


