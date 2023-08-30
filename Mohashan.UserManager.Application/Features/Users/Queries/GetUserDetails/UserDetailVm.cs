namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUserDetails;

public class UserDetailVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UserTypeDto UserType { get; set; } = default!;
    public DateTime CreatedDateTime { get; set; }
}