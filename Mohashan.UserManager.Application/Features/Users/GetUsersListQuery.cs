using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Users;

public class GetUsersListQuery:IRequest<List<UsersListVm>>
{
}


