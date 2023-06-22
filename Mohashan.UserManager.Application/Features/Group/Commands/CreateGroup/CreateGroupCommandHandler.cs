using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Group.Commands.CreateGroup;

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Domain.Entities.Group> _groupRepository;

    public CreateGroupCommandHandler(IMapper mapper,IAsyncRepository<Domain.Entities.Group> groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }
    public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.AddAsync(_mapper.Map<Domain.Entities.Group>(request));
        return group.Id;
    }
}
