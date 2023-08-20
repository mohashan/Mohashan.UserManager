using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersList;
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

namespace Mohashan.UserManager.Application.UnitTests.Users.Queries;

public class GetUsersListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    public GetUsersListQueryHandlerTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetUsersListTest()
    {
        var handler = new GetUsersListQueryHandler(_mapper,_mockUserRepository.Object);
        var userListQuery = new GetUsersListQuery
        {
            PageCount = 10,
            PageNumber = 1
        };
        var result =await handler.Handle(userListQuery, CancellationToken.None);

        result.ShouldBeOfType<List<UsersListVm>>();
        result.Count.ShouldBe(10);
    }
}
