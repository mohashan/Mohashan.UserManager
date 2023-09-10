using FluentValidation;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Group.Commands.CreateGroup;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    private readonly IGroupRepository _groupRepository;

    public CreateGroupCommandValidator(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(100).WithMessage("{PropertyName} length must be less than 100")
            .MustAsync(GroupNameIsUnique).WithMessage("This group name is exist, try another");
    }

    private async Task<bool> GroupNameIsUnique(string groupName, CancellationToken cancellationToken)
    {
        return await _groupRepository.GroupNameIsUnique(groupName);
    }
}