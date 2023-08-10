namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;

public class UserExportFileVm
{
    public string UserExportFileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public byte[] Data { get; set; }
}