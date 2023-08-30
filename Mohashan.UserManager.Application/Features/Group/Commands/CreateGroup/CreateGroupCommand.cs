using MediatR;

namespace Mohashan.UserManager.Application.Features.Group.Commands.CreateGroup;

public class CreateGroupCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Group Name : {Name}";
    }
}