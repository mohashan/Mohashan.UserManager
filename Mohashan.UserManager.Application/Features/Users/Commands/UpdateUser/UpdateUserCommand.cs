using MediatR;

namespace Mohashan.UserManager.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid Type { get; set; }
}