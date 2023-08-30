using FluentValidation;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Group.Commands.UpdateGroup;

public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    private readonly IGroupRepository _groupRepository;

    public UpdateGroupCommandValidator(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(IsGroupExist).WithMessage("{PropertyName} is not exist");

        RuleFor(c => c.Name)
            .MaximumLength(50).WithMessage("{PropertyName} length must be less than 50");
    }

    private async Task<bool> IsGroupExist(Guid id, CancellationToken cancellationToken)
    {
        return await _groupRepository.GetByIdAsync(id) != null;
    }
}