using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Commands.CreateUser;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Mohashan.UserManager.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var handler = new CreateUserCommandHandler(_mapper,_mockUserRepository.Object);

        await handler.Handle(new CreateUserCommand { Name = "Test2", Type = Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}") },
            CancellationToken.None);

        var allUsers = await _mockUserRepository.Object.GetListAsync();
        allUsers.Count.ShouldBe(13);
        allUsers.FirstOrDefault(c=>c.Name == "Test2").Name.ShouldBe("Test2");
    }
}
