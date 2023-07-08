using FluentValidation;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Group.Commands.DeleteGroup;

public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
{
    private readonly IGroupRepository _groupRepository;

    public DeleteGroupCommandValidator(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(IsGroupExist).WithMessage("{PropertyName} is not exist");
    }
    private async Task<bool> IsGroupExist(Guid id, CancellationToken cancellationToken)
    {
        return await _groupRepository.GetByIdAsync(id) != null;
    }
}