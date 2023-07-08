using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<User> _userRepository;

    public UpdateUserCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.User> userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(request.Id);
        _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(Domain.Entities.User));
        await _userRepository.UpdateAsync(userToUpdate);
        return Unit.Value;
    }
}