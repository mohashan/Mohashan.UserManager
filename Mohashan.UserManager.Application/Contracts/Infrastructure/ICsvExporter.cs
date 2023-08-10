using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Contracts.Infrastructure;

public interface ICsvExporter
{
    byte[] ExportUsersToCsv(List<UserExportDto> userExportDtos);
}
