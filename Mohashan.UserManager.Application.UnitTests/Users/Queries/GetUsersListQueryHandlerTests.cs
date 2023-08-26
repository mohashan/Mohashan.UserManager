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
using System.Xml.XPath;

namespace Mohashan.UserManager.Application.UnitTests.Users.Queries;

public class GetUsersListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly GetUsersListQuery usersListQuery;
    public GetUsersListQueryHandlerTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
        usersListQuery = new GetUsersListQuery();
    }

    [Fact]
    public async Task GetUsersListTest()
    {
        var handler = new GetUsersListQueryHandler(_mapper,_mockUserRepository.Object);
        usersListQuery.PageCount = 10;
        usersListQuery.PageNumber = 1;

        var result =await handler.Handle(usersListQuery, CancellationToken.None);

        result.ShouldBeOfType<List<UsersListVm>>();
        result.Count.ShouldBe(10);
    }

    [Fact]
    public async Task GetJustOneFromUsersListTest()
    {
        var handler = new GetUsersListQueryHandler(_mapper, _mockUserRepository.Object);
        usersListQuery.PageCount = 1;
        usersListQuery.PageNumber = 1;

        var result = await handler.Handle(usersListQuery, CancellationToken.None);

        result.ShouldBeOfType<List<UsersListVm>>();
        result.Count.ShouldBe(1);
    }
}

