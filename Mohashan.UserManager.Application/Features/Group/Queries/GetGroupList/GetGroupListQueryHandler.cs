using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Group.Queries.GetGroupList;

public class GetGroupListQueryHandler : IRequestHandler<GetGroupListQuery, List<GroupListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Domain.Entities.Group> _groupRepository;

    public GetGroupListQueryHandler(IMapper mapper,IAsyncRepository<Domain.Entities.Group> groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }
    public async Task<List<GroupListVm>> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
    {
        var groups = (await _groupRepository.GetAllPagedAsync()).OrderBy(x => x.Name).ToList();
        return _mapper.Map<List<GroupListVm>>(groups);
    }
}
