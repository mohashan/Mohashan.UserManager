using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Group.Queries.GetGroupList;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersList;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Mohashan.UserManager.Application.UnitTests.Groups.Queries;

public class GetGroupsListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IGroupRepository> _mockGroupRepository;
    private readonly GetGroupListQuery groupListQuery;

    public GetGroupsListQueryHandlerTests()
    {
        _mockGroupRepository = RepositoryMocks.GetGroupRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
        groupListQuery = new GetGroupListQuery();
    }

    [Fact]
    public async Task Get_GroupList_Test()
    {
        var handler = new GetGroupListQueryHandler(_mapper, _mockGroupRepository.Object);
        groupListQuery.PageCount = 10;
        groupListQuery.PageNumber = 1;

        var result = await handler.Handle(groupListQuery, CancellationToken.None);

        result.ShouldBeOfType<List<GroupListVm>>();
        result.Count.ShouldBe(2);
    }
}