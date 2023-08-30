using MediatR;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.UpdateFeature;

public class UpdateFeatureCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}