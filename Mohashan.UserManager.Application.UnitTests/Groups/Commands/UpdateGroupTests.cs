using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Group.Commands.UpdateGroup;
using Mohashan.UserManager.Application.Features.Users.Commands.UpdateUser;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.UnitTests.Groups.Commands;

public class UpdateGroupTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IGroupRepository> _mockGroupRepository;

    public UpdateGroupTests()
    {
        _mockGroupRepository = RepositoryMocks.GetGroupRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Update_Group_Test()
    {
        var group = (await _mockGroupRepository.Object.GetListAsync()).FirstOrDefault(c => c.Name.Contains("TestGroup"));
        group.ShouldNotBeNull();
        var handler = new UpdateGroupCommandHandler(_mapper, _mockGroupRepository.Object);
        var result = await handler.Handle(new UpdateGroupCommand { Id = group.Id, Name = "TestGroupUpdate" }, CancellationToken.None);

        var oldGroup = (await _mockGroupRepository.Object.GetListAsync()).FirstOrDefault(c => c.Id == group.Id);
        oldGroup.ShouldNotBeNull();
        oldGroup.IsDeleted.ShouldBe(false);
        oldGroup.Name.ShouldBe("TestGroupUpdate");
        oldGroup.LastModifiedDateTime.ShouldNotBeNull();
        oldGroup.LastModifiedDateTime.Value.ShouldBeGreaterThan<DateTime>(DateTime.UtcNow.AddSeconds(-1));
    }
}