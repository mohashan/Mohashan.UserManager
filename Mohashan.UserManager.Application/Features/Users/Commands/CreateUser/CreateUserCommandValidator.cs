using FluentValidation;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must be less than 50")
            .MustAsync(UsernameIsUnique).WithMessage("This username is exist, try another");

        RuleFor(c => c.Type)
            .NotEmpty().WithMessage("{PropertyName} must be assigned");
    }

    private async Task<bool> UsernameIsUnique(string userName,CancellationToken cancellationToken)
    {
        return await _userRepository.UsernameIsUnique(userName);
    }
}
