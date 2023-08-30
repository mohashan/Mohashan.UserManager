using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUserFeatures;

public class GetUserFeaturesQueryHandler : IRequestHandler<GetUserFeaturesQuery, List<UserFeaturesDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetUserFeaturesQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<List<UserFeaturesDto>> Handle(GetUserFeaturesQuery request, CancellationToken cancellationToken)
    {
        var userFeatures = await _userRepository.GetUserFeatures(request.UserId);

        return _mapper.Map<List<UserFeaturesDto>>(userFeatures);
    }
}