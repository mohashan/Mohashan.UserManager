using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Infrastructure;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersList;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Mohashan.UserManager.Application.UnitTests.Users.Queries;

public class GetUsersExportQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly GetUsersExportQuery usersExportQuery;
    private readonly Mock<ICsvExporter> csvExporter;
    public GetUsersExportQueryHandlerTests()
    {
        _mockUserRepository = RepositoryMocks.GetUserRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
        usersExportQuery = new GetUsersExportQuery();
        csvExporter = ExporterMocks.GetCsvExporter();
    }

    [Fact]
    public async Task GetUsersListTest()
    {
        var handler = new GetUsersExportQueryHandler(_mapper, _mockUserRepository.Object,csvExporter.Object);

        var result = await handler.Handle(usersExportQuery, CancellationToken.None);

        result.ShouldBeOfType<UserExportFileVm>();
        result.ContentType.ShouldBe("text/csv");
        result.Data.ShouldBeOfType<byte[]>();
        result.UserExportFileName.ShouldContain(".csv");
        result.UserExportFileName.ShouldNotBeNull();
        result.UserExportFileName.ShouldNotBeEmpty();
    }


}
