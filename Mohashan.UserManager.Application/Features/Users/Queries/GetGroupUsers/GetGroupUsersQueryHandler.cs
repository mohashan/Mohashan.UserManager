using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetGroupUsers;

public class GetGroupUsersQueryHandler : IRequestHandler<GetGroupUsersQuery, List<GroupUsersListVm>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetGroupUsersQueryHandler(IMapper mapper,IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<List<GroupUsersListVm>> Handle(GetGroupUsersQuery request, CancellationToken cancellationToken)
    {
        var Users = (await _userRepository.GetGroupUsers(request.GroupId)).OrderBy(c=>c.Name).ToList();

        return _mapper.Map<List<GroupUsersListVm>>(Users);
    }
}
