using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Group.Commands.CreateGroup;
using Mohashan.UserManager.Application.Features.Users.Commands.CreateUser;
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

public class CreateGroupTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IGroupRepository> _mockGroupRepository;

    public CreateGroupTests()
    {
        _mockGroupRepository = RepositoryMocks.GetGroupRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidGroup_AddedToGroupRepo()
    {
        var handler = new CreateGroupCommandHandler(_mapper, _mockGroupRepository.Object);
        string groupName = "HandleValidGroupAdd";
        await handler.Handle(new CreateGroupCommand { Name = groupName },
            CancellationToken.None);

        var allGroups = await _mockGroupRepository.Object.GetListAsync();
        var group = allGroups.FirstOrDefault(c => c.Name == groupName);
        group.ShouldNotBeNull();
        group.Name.ShouldBe(groupName);
    }

    [Fact]
    public async Task Error_On_Invalid_GroupName_Added_To_GroupRepo_Test()
    {
        var handler = new CreateGroupCommandHandler(_mapper, _mockGroupRepository.Object);
        CreateGroupCommand groupCommand = new CreateGroupCommand { Name = ""};
        var error = await Should.ThrowAsync<Exceptions.ValidationException>(handler.Handle(groupCommand, CancellationToken.None));

        error.ValidationErrors.Count.ShouldBeGreaterThan(0);
        error.ValidationErrors.ShouldContain($"{nameof(groupCommand.Name)} is required");
    }

    [Fact]
    public async Task Error_On_Duplicate_GroupName_Added_To_GroupRepo_Test()
    {
        var handler = new CreateGroupCommandHandler(_mapper, _mockGroupRepository.Object);
        string groupName = (await _mockGroupRepository.Object.GetListAsync()).FirstOrDefault().Name;

        CreateGroupCommand groupCommand = new CreateGroupCommand { Name = groupName };
        var error = await Should.ThrowAsync<Exceptions.ValidationException>(handler.Handle(groupCommand, CancellationToken.None));

        error.ValidationErrors.Count.ShouldBeGreaterThan(0);
        error.ValidationErrors.ShouldContain($"This group name is exist, try another");
    }
}
