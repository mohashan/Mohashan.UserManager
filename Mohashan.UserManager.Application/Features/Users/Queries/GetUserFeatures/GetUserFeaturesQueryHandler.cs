using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUserFeatures;

public class GetUserFeaturesQueryHandler : IRequestHandler<GetUserFeaturesQuery, UserFeaturesListVm>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserFeaturesQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<UserFeaturesListVm> Handle(GetUserFeaturesQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserFeatures(request.UserId);

        return _mapper.Map<UserFeaturesListVm>(user);
    }
}