using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Group.Commands.DeleteGroup;
using Mohashan.UserManager.Application.Features.Users.Commands.DeleteUser;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.UnitTests.Groups.Commands;

public class DeleteGroupTests
{
    private readonly Mock<IGroupRepository> _mockGroupRepository;

    public DeleteGroupTests()
    {
        _mockGroupRepository = RepositoryMocks.GetGroupRepository();
    }

    [Fact]
    public async Task Delete_Group_Test()
    {
        var allGroups = await _mockGroupRepository.Object.GetListAsync();
        var groupCount = allGroups.Count();
        var group = allGroups.FirstOrDefault(c => c.Name.Contains("TestGroup"));
        group.ShouldNotBeNull();
        var handler = new DeleteGroupCommandHandler(_mockGroupRepository.Object);
        var result = await handler.Handle(new DeleteGroupCommand { Id = group.Id }, CancellationToken.None);

        var allNewGroups = await _mockGroupRepository.Object.GetListAsync();
        var oldGroup = allNewGroups.FirstOrDefault(c => c.Id == group.Id);
        oldGroup.ShouldNotBeNull();
        oldGroup.IsDeleted.ShouldBe(true);
        oldGroup.DeletedDateTime.ShouldNotBeNull();
        oldGroup.DeletedDateTime.Value.ShouldBeGreaterThan<DateTime>(DateTime.UtcNow.AddSeconds(-1));
    }
}
