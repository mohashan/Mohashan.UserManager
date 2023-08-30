using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Commands.CreateUser;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Mohashan.UserManager.Application.UnitTests.Users.Commands;

public class CreatUserTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;

    public CreatUserTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidUser_AddedToUserRepo()
    {
        var handler = new CreateUserCommandHandler(_mapper, _mockUserRepository.Object);
        string username = "HandleValidUserAdd";
        await handler.Handle(new CreateUserCommand { Name = username, Type = Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}") },
            CancellationToken.None);

        var allUsers = await _mockUserRepository.Object.GetListAsync();
        var user = allUsers.FirstOrDefault(c => c.Name == username);
        user.ShouldNotBeNull();
        user.UserTypeId.ShouldBe(Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}"));
        user.Name.ShouldBe(username);
    }

    [Fact]
    public async Task Error_On_Invalid_Username_Added_To_UserRepo_Test()
    {
        var handler = new CreateUserCommandHandler(_mapper, _mockUserRepository.Object);
        CreateUserCommand userCommand = new CreateUserCommand { Type = Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}") };
        var error = await Should.ThrowAsync<Exceptions.ValidationException>(handler.Handle(userCommand, CancellationToken.None));

        error.ValidationErrors.Count.ShouldBeGreaterThan(0);
        error.ValidationErrors.ShouldContain($"{nameof(userCommand.Name)} is required");
    }

    [Fact]
    public async Task Error_On_Invalid_UserType_Added_To_UserRepo_Test()
    {
        var handler = new CreateUserCommandHandler(_mapper, _mockUserRepository.Object);
        CreateUserCommand userCommand = new CreateUserCommand { Name = "Test2" };
        var error = await Should.ThrowAsync<Exceptions.ValidationException>(handler.Handle(userCommand, CancellationToken.None));

        error.ValidationErrors.Count.ShouldBeGreaterThan(0);
        error.ValidationErrors.ShouldContain($"{nameof(userCommand.Type)} must be assigned");
    }

    [Fact]
    public async Task Error_On_Duplicate_Username_Added_To_UserRepo_Test()
    {
        var handler = new CreateUserCommandHandler(_mapper, _mockUserRepository.Object);
        string username = "HandleValidUserAdd";
        await handler.Handle(new CreateUserCommand { Name = username, Type = Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}") },
            CancellationToken.None);
        CreateUserCommand userCommand = new CreateUserCommand { Name = username, Type = Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}") };
        var error = await Should.ThrowAsync<Exceptions.ValidationException>(handler.Handle(userCommand, CancellationToken.None));

        error.ValidationErrors.Count.ShouldBeGreaterThan(0);
        error.ValidationErrors.ShouldContain($"This username is exist, try another");
    }
}