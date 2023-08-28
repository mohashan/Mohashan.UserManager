using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Queries.GetGroupUsers;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Mohashan.UserManager.Application.UnitTests.Users.Queries;

public class GetGroupUsersQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly GetGroupUsersQuery groupUsersQuery;
    public GetGroupUsersQueryHandlerTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
        groupUsersQuery = new GetGroupUsersQuery();
    }

    [Fact]
    public async Task Get_GroupUsers_Test()
    {
        var handler = new GetGroupUsersQueryHandler(_mapper, _mockUserRepository.Object);
        groupUsersQuery.GroupId = Guid.Parse("{be8331cf-6893-4233-8efb-c485a179bb53}");

        var result = await handler.Handle(groupUsersQuery, CancellationToken.None);

        result.ShouldBeOfType<List<GroupUsersListVm>>();
        result.Count.ShouldBe(1);
    }

    [Fact]
    public async Task Get_Empty_List_Of_Features_If_GroupId_Is_Not_Exist_Test()
    {
        var handler = new GetGroupUsersQueryHandler(_mapper, _mockUserRepository.Object);
        groupUsersQuery.GroupId = Guid.Parse("{a9bbae60-9326-4059-ada5-ab38bb44436d}");

        var result = await handler.Handle(groupUsersQuery, CancellationToken.None);
        result.ShouldNotBeNull();
        result.Count.ShouldBe(0);
    }

}
