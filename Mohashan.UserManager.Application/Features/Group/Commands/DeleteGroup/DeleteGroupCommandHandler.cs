using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Group.Commands.DeleteGroup;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand>
{
    private readonly IAsyncRepository<Domain.Entities.Group> _groupRepository;

    public DeleteGroupCommandHandler(IAsyncRepository<Domain.Entities.Group> groupRepository)
    {
        _groupRepository = groupRepository;
    }
    public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        await _groupRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
