using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;

public class UserExportDto
{
    public string Name { get; set; } = string.Empty;
    public string UserTypeName { get; set; } = string.Empty;
    public DateTime CreatedDateTime { get; set; }
}
