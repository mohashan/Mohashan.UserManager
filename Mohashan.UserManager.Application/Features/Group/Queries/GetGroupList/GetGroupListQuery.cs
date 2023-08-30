using MediatR;

namespace Mohashan.UserManager.Application.Features.Group.Queries.GetGroupList;

public class GetGroupListQuery : IRequest<List<GroupListVm>>
{
    public int PageCount { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
}