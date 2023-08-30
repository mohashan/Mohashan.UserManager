using MediatR;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.DeleteFeature;

public class DeleteFeatureCommand : IRequest
{
    public Guid Id { get; set; }
}