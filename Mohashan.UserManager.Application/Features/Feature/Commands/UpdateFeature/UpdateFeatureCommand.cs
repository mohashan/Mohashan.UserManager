using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.UpdateFeature;

public class UpdateFeatureCommand:IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
