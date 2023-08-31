using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Group.Queries.GetGroupDetails;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUserDetails;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.UnitTests.Groups.Queries;

public class GetGroupDetailQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IGroupRepository> _mockGroupRepository;
    private readonly GetGroupDetailQuery groupDetailQuery;

    public GetGroupDetailQueryHandlerTests()
    {
        _mockGroupRepository = RepositoryMocks.GetGroupRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
        groupDetailQuery = new GetGroupDetailQuery();
    }

    [Fact]
    public async Task Get_GroupDetail_Test()
    {
        var handler = new GetGroupDetailQueryHandler(_mapper, _mockGroupRepository.Object);
        groupDetailQuery.Id = Guid.Parse("{C189A30E-E1A0-4D1C-BBAD-59AC4F10A94D}");

        var result = await handler.Handle(groupDetailQuery, CancellationToken.None);

        result.ShouldBeOfType<GroupDetailVm>();
        result.Id.ShouldBe(groupDetailQuery.Id);
        result.Name.ShouldBe("AdminGroup");
    }

    [Fact]
    public async Task Throw_Exception_If_Group_Is_Not_Exist_Test()
    {
        var handler = new GetGroupDetailQueryHandler(_mapper, _mockGroupRepository.Object);
        groupDetailQuery.Id = Guid.Parse("{0AC3E478-CF2F-4840-B933-A4FF4609F2E7}");

        _ = await Should.ThrowAsync<ArgumentException>(() => handler.Handle(groupDetailQuery, CancellationToken.None));
    }
}
