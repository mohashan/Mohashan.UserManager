using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Group.Queries.GetGroupList;

public class GroupListVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
