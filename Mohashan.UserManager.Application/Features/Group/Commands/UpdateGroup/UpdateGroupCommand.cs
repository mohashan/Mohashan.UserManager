using MediatR;

namespace Mohashan.UserManager.Application.Features.Group.Commands.UpdateGroup;

public class UpdateGroupCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}