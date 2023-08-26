using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUserFeatures;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Mohashan.UserManager.Application.UnitTests.Users.Queries;

public class GetUserFeaturesQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly GetUserFeaturesQuery userFeaturesQuery;
    public GetUserFeaturesQueryHandlerTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
        userFeaturesQuery = new GetUserFeaturesQuery();
    }

    [Fact]
    public async Task GetUserFeaturesTest()
    {
        var handler = new GetUserFeaturesQueryHandler(_mapper, _mockUserRepository.Object);
        userFeaturesQuery.UserId = Guid.Parse("{5c56c180-6147-4edf-a969-04b83bd49cfa}");

        var result = await handler.Handle(userFeaturesQuery, CancellationToken.None);

        result.ShouldBeOfType<List<UserFeaturesDto>>();
        result.Count.ShouldBe(2);
    }

}
