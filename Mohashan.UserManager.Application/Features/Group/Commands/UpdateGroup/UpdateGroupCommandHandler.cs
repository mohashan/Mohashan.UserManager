using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Group.Commands.UpdateGroup;

public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Domain.Entities.Group> _groupRepository;

    public UpdateGroupCommandHandler(IMapper mapper,IAsyncRepository<Domain.Entities.Group> groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }
    public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var groupToUpdate = await _groupRepository.GetByIdAsync(request.Id);
        _mapper.Map(request, groupToUpdate,typeof(UpdateGroupCommand),typeof(Domain.Entities.Group));
        await _groupRepository.UpdateAsync(groupToUpdate);
        return Unit.Value;
    }
}
