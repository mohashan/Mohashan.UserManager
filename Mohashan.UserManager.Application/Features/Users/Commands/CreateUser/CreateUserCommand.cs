using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand:IRequest<CreateUserCommandResponse>
{
    public string Name { get; set; } = string.Empty;
    public Guid Type { get; set; }
    public override string ToString()
    {
        return $"User name : {Name}";
    }
}
