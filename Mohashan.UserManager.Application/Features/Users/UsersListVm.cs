using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Features.Users;

public class UsersListVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

}