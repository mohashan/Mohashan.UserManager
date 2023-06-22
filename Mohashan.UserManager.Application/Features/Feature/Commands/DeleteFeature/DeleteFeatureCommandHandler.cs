using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.DeleteFeature;

public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
{
    private readonly IAsyncRepository<Domain.Entities.Feature> _featureRepository;

    public DeleteFeatureCommandHandler(IAsyncRepository<Domain.Entities.Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }
    public async Task<Unit> Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        await _featureRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
