using MediatR;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;

public class GetUsersExportQuery : IRequest<UserExportFileVm>
{
}