using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.DeleteFeature;

public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
{
    private readonly IFeatureRepository _featureRepository;

    public DeleteFeatureCommandHandler(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task<Unit> Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteFeatureCommandValidator(_featureRepository);
        var validatorResult = await validator.ValidateAsync(request);
        if (!validatorResult.IsValid)
            throw new Exceptions.ValidationException(validatorResult);

        await _featureRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}