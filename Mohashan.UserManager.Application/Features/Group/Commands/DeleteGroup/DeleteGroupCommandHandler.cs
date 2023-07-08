using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Feature.Commands.DeleteFeature;

namespace Mohashan.UserManager.Application.Features.Group.Commands.DeleteGroup;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand>
{
    private readonly IGroupRepository _groupRepository;

    public DeleteGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteGroupCommandValidator(_groupRepository);
        var validatorResult = await validator.ValidateAsync(request);
        if (!validatorResult.IsValid)
            throw new Exceptions.ValidationException(validatorResult);

        await _groupRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
