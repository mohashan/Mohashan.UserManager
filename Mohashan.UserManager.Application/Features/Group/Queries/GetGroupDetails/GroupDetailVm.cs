using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Group.Queries.GetGroupDetails;

public class GroupDetailVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime InsertDateTime { get; set; }
    public ICollection<UserGroupDto>? Users { get; set; }
}
