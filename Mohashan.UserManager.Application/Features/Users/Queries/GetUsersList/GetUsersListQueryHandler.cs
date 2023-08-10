using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUserDetails;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUsersList;

public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UsersListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<User> _userRepository;

    public GetUsersListQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<List<UsersListVm>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        var users = (await _userRepository.GetAllPagedAsync()).OrderBy(c => c.Name);
        return _mapper.Map<List<UsersListVm>>(users);
    }
}



