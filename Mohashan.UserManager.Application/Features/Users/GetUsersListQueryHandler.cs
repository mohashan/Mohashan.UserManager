using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Features.Users;

public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UsersListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<User> _userRepository;

    public GetUsersListQueryHandler(IMapper mapper,IAsyncRepository<User> userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<List<UsersListVm>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
    {
        var users = (await _userRepository.GetAllAsync()).OrderBy(c => c.Name);
        return _mapper.Map<List<UsersListVm>>(users);
    }
}

public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery,UserDetailVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<User> _userRepository;
    private readonly IAsyncRepository<UserType> _userTypeRepository;

    public GetUserDetailQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository, IAsyncRepository<UserType> userTypeRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userTypeRepository = userTypeRepository;
    }
    public async Task<UserDetailVm> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        var userDetail = _mapper.Map<UserDetailVm>(user);

        var userType = await _userTypeRepository.GetByIdAsync(user.UserTypeId);
        userDetail.UserType = _mapper.Map<UserTypeDto>(userType);

        return userDetail;
    }
}


