using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUserDetails;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Mohashan.UserManager.Application.UnitTests.Users.Queries;

public class GetUserDetailQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IUserTypeRepository> _mockUserTypeRepository;
    private readonly GetUserDetailQuery userDetailQuery;

    public GetUserDetailQueryHandlerTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
        _mockUserTypeRepository = RepositoryMocks.GetUserTypeRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
        userDetailQuery = new GetUserDetailQuery();
    }

    [Fact]
    public async Task Get_UserDetail_Test()
    {
        var handler = new GetUserDetailQueryHandler(_mapper, _mockUserRepository.Object, _mockUserTypeRepository.Object);
        userDetailQuery.Id = Guid.Parse("{5c56c180-6147-4edf-a969-04b83bd49cfa}");

        var result = await handler.Handle(userDetailQuery, CancellationToken.None);

        result.ShouldBeOfType<UserDetailVm>();
        result.Id.ShouldBe(userDetailQuery.Id);
        result.UserType.Id.ShouldBe(Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}"));
        result.Name.ShouldBe("AdminTest");
    }

    [Fact]
    public async Task Throw_Exception_If_User_Is_Not_Exist_Test()
    {
        var handler = new GetUserDetailQueryHandler(_mapper, _mockUserRepository.Object, _mockUserTypeRepository.Object);
        userDetailQuery.Id = Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}");

        _ = await Should.ThrowAsync<ArgumentException>(() => handler.Handle(userDetailQuery, CancellationToken.None));
    }
}