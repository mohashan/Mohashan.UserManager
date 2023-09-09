using AutoMapper;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Feature.Queries.GetFeatureDetails;
using Mohashan.UserManager.Application.Features.Group.Queries.GetGroupDetails;
using Mohashan.UserManager.Application.Profiles;
using Mohashan.UserManager.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.UnitTests.Features.Queries;

public class GetFeatureDetailQueryHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IFeatureRepository> _mockFeatureRepository;
    private readonly GetFeatureDetailQuery featureDetailQuery;

    public GetFeatureDetailQueryHandlerTest()
    {
        _mockFeatureRepository = RepositoryMocks.GetFeatureRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
        featureDetailQuery = new GetFeatureDetailQuery();
    }

    [Fact]
    public async Task Get_FeatureDetail_Test()
    {
        var handler = new GetFeatureDetailQueryHandler(_mapper, _mockFeatureRepository.Object);
        featureDetailQuery.Id = Guid.Parse("{9AB012A8-C5B6-463B-85FE-AEFD20E2C477}");

        var result = await handler.Handle(featureDetailQuery, CancellationToken.None);

        result.ShouldBeOfType<FeatureDetailVm>();
        result.Id.ShouldBe(featureDetailQuery.Id);
        result.Name.ShouldBe("Email");
    }

    [Fact]
    public async Task Throw_Exception_If_Feature_Is_Not_Exist_Test()
    {
        var handler = new GetFeatureDetailQueryHandler(_mapper, _mockFeatureRepository.Object);
        featureDetailQuery.Id = Guid.Parse("{0AC3E478-CF2F-4840-B933-A4FF4609F2E7}");

        _ = await Should.ThrowAsync<ArgumentException>(() => handler.Handle(featureDetailQuery, CancellationToken.None));
    }
}
