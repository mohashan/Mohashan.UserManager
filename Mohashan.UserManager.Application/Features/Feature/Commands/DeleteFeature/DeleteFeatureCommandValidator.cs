using FluentValidation;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.DeleteFeature;

public class DeleteFeatureCommandValidator : AbstractValidator<DeleteFeatureCommand>
{
    private readonly IFeatureRepository _featureRepository;

    public DeleteFeatureCommandValidator(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(IsFeatureExist).WithMessage("{PropertyName} is not exist");
    }

    private async Task<bool> IsFeatureExist(Guid id, CancellationToken cancellationToken)
    {
        return await _featureRepository.GetByIdAsync(id) != null;
    }
}