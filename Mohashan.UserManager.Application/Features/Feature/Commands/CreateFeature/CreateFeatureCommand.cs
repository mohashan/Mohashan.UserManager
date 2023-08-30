using MediatR;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.CreateFeature;

public class CreateFeatureCommand : IRequest<CreateFeatureCommandResponse>
{
    public string Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Group Name : {Name}";
    }
}