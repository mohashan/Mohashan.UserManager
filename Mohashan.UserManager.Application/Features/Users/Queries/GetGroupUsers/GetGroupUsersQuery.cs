using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetGroupUsers;

public class GetGroupUsersQuery:IRequest<List<GroupUsersListVm>>
{
    public Guid GroupId { get; set; }
}
