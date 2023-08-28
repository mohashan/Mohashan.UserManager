using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Commands.UpdateUser;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Mohashan.UserManager.Application.UnitTests.Users.Commands;

public class UpdateUserTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    public UpdateUserTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Update_User_Test()
    {
        var user = (await _mockUserRepository.Object.GetListAsync()).FirstOrDefault(c => c.Name.Contains("test"));
        user.ShouldNotBeNull();
        var handler = new UpdateUserCommandHandler(_mapper,_mockUserRepository.Object);
        var result = await handler.Handle(new UpdateUserCommand { Id = user.Id, Name = "testUpdate" }, CancellationToken.None);

        var oldUser = (await _mockUserRepository.Object.GetListAsync()).FirstOrDefault(c => c.Id == user.Id);
        oldUser.ShouldNotBeNull();
        oldUser.IsDeleted.ShouldBe(false);
        oldUser.Name.ShouldBe("testUpdate");
        oldUser.LastModifiedDateTime.ShouldNotBeNull();
        oldUser.LastModifiedDateTime.Value.ShouldBeGreaterThan<DateTime>(DateTime.UtcNow.AddSeconds(-1));
    }
}
