using MediatR;
using Mohashan.UserManager.Application.Features.Group.Commands.UpdateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand:IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set;} = string.Empty;
    public Guid Type { get; set; }
}
