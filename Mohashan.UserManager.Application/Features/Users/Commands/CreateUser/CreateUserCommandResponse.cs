namespace Mohashan.UserManager.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid Type { get; set; }
}