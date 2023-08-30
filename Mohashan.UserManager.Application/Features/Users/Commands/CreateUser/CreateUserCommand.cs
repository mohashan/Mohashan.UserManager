using MediatR;
using Mohashan.UserManager.Application.Responses;

namespace Mohashan.UserManager.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<BaseResponse<CreateUserCommandResponse>>
{
    public string Name { get; set; } = string.Empty;
    public Guid Type { get; set; }

    public override string ToString()
    {
        return $"User name : {Name}";
    }
}