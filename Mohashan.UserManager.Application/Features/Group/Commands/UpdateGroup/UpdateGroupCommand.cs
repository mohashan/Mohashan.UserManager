using MediatR;
using Mohashan.UserManager.Application.Features.Feature.Commands.UpdateFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Group.Commands.UpdateGroup;

public class UpdateGroupCommand:IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
