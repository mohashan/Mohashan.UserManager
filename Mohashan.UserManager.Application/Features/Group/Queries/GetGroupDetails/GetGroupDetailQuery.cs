using MediatR;

namespace Mohashan.UserManager.Application.Features.Group.Queries.GetGroupDetails;

public class GetGroupDetailQuery : IRequest<GroupDetailVm>
{
    public Guid Id { get; set; }
}