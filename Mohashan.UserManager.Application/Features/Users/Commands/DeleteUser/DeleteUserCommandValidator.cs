using FluentValidation;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    private readonly IAsyncRepository<User> _userRepository;

    public DeleteUserCommandValidator(IAsyncRepository<Domain.Entities.User> userRepository)
    {
        _userRepository = userRepository;
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(IsUserExist);
    }

    private async Task<bool> IsUserExist(Guid id, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByIdAsync(id) != null;
    }
}