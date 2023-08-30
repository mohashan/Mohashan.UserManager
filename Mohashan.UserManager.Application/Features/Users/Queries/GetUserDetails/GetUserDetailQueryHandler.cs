using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUserDetails;

public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailVm>
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

        if (user is null)
            throw new ArgumentException("User is not exist");

        var userDetail = _mapper.Map<UserDetailVm>(user);

        var userType = await _userTypeRepository.GetByIdAsync(user.UserTypeId);
        userDetail.UserType = _mapper.Map<UserTypeDto>(userType);

        return userDetail;
    }
}