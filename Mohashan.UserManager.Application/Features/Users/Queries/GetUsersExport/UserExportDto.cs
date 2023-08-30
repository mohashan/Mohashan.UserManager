namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;

public class UserExportDto
{
    public string Name { get; set; } = string.Empty;
    public string UserTypeName { get; set; } = string.Empty;
    public DateTime CreatedDateTime { get; set; }
}