using FluentValidation;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.UpdateFeature;

public class UpdateFeatureCommandValidator : AbstractValidator<UpdateFeatureCommand>
{
    private readonly IFeatureRepository _featureRepository;

    public UpdateFeatureCommandValidator(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(IsFeatureExist).WithMessage("{PropertyName} is not exist");

        RuleFor(c => c.Name)
            .MaximumLength(50).WithMessage("{PropertyName} length must be less than 50");
    }

    private async Task<bool> IsFeatureExist(Guid id, CancellationToken cancellationToken)
    {
        return await _featureRepository.GetByIdAsync(id) != null;
    }
}