using MediatR;

namespace Mohashan.UserManager.Application.Features.Group.Commands.DeleteGroup;

public class DeleteGroupCommand : IRequest
{
    public Guid Id { get; set; }
}