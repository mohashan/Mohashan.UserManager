using MediatR;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetGroupUsers;

public class GetGroupUsersQuery : IRequest<List<GroupUsersListVm>>
{
    public Guid GroupId { get; set; }
}