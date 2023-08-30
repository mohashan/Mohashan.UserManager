using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;

namespace Mohashan.UserManager.Application.Contracts.Infrastructure;

public interface ICsvExporter
{
    byte[] ExportUsersToCsv(List<UserExportDto> userExportDtos);
}