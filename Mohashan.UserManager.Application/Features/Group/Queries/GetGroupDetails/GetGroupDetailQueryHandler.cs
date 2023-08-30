using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Group.Queries.GetGroupDetails;

public class GetGroupDetailQueryHandler : IRequestHandler<GetGroupDetailQuery, GroupDetailVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Domain.Entities.Group> _groupRepository;

    public GetGroupDetailQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Group> groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }

    public async Task<GroupDetailVm> Handle(GetGroupDetailQuery request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.GetByIdAsync(request.Id);

        var groupVm = _mapper.Map<GroupDetailVm>(group);
        groupVm.Users = _mapper.Map<List<UserGroupDto>>(group.UserGroups?.ToList());
        return groupVm;
    }
}