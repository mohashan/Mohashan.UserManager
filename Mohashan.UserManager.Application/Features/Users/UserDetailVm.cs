using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Features.Users;

public class UserDetailVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UserTypeDto UserType { get; set; } = default!;
    public DateTime CreatedDateTime { get; set; }
}