using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.CreateFeature;

public class CreateFeatureCommand:IRequest<CreateFeatureCommandResponse>
{
    public string Name { get; set; } = string.Empty;
    public override string ToString()
    {
        return $"Group Name : {Name}";
    }
}
