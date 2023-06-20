using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUsersList;

public class GetUsersListQuery : IRequest<List<UsersListVm>>
{
}


