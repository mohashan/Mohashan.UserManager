using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Group.Commands.UpdateGroup;

public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand>
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;

    public UpdateGroupCommandHandler(IMapper mapper, IGroupRepository groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }

    public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateGroupCommandValidator(_groupRepository);
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new Exceptions.ValidationException(validationResult);
        }
        var groupToUpdate = await _groupRepository.GetByIdAsync(request.Id);
        _mapper.Map(request, groupToUpdate, typeof(UpdateGroupCommand), typeof(Domain.Entities.Group));
        await _groupRepository.UpdateAsync(groupToUpdate);
        return Unit.Value;
    }
}