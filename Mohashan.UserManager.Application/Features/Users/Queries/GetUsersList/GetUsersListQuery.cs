using MediatR;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUsersList;

public class GetUsersListQuery : IRequest<List<UsersListVm>>
{
    public int PageCount { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
}