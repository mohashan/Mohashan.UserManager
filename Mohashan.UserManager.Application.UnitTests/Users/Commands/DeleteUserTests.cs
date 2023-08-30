using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Commands.DeleteUser;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Mohashan.UserManager.Application.UnitTests.Users.Commands;

public class DeleteUserTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;

    public DeleteUserTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
    }

    [Fact]
    public async Task Delete_User_Test()
    {
        var allUsers = await _mockUserRepository.Object.GetListAsync();
        var userCount = allUsers.Count();
        var user = allUsers.FirstOrDefault(c => c.Name.Contains("test"));
        user.ShouldNotBeNull();
        var handler = new DeleteUserCommandHandler(_mockUserRepository.Object);
        var result = await handler.Handle(new DeleteUserCommand { Id = user.Id }, CancellationToken.None);

        var allNewUsers = await _mockUserRepository.Object.GetListAsync();
        var oldUser = allNewUsers.FirstOrDefault(c => c.Id == user.Id);
        oldUser.ShouldNotBeNull();
        oldUser.IsDeleted.ShouldBe(true);
        oldUser.DeletedDateTime.ShouldNotBeNull();
        oldUser.DeletedDateTime.Value.ShouldBeGreaterThan<DateTime>(DateTime.UtcNow.AddSeconds(-1));
    }
}