using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersList;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Mohashan.UserManager.Application.UnitTests.Users.Queries;

public class GetUsersListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly GetUsersListQuery usersListQuery;

    public GetUsersListQueryHandlerTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
        usersListQuery = new GetUsersListQuery();
    }

    [Fact]
    public async Task Get_UsersList_Test()
    {
        var handler = new GetUsersListQueryHandler(_mapper, _mockUserRepository.Object);
        usersListQuery.PageCount = 10;
        usersListQuery.PageNumber = 1;

        var result = await handler.Handle(usersListQuery, CancellationToken.None);

        result.ShouldBeOfType<List<UsersListVm>>();
        result.Count.ShouldBe(10);
    }

    [Fact]
    public async Task Get_Just_One_From_UsersList_Test()
    {
        var handler = new GetUsersListQueryHandler(_mapper, _mockUserRepository.Object);
        usersListQuery.PageCount = 1;
        usersListQuery.PageNumber = 1;

        var result = await handler.Handle(usersListQuery, CancellationToken.None);

        result.ShouldBeOfType<List<UsersListVm>>();
        result.Count.ShouldBe(1);
    }
}