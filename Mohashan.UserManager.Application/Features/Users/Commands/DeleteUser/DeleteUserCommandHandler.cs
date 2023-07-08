using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IAsyncRepository<User> _userRepository;

    public DeleteUserCommandHandler(IAsyncRepository<Mohashan.UserManager.Domain.Entities.User> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
