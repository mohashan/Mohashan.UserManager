using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Feature.Queries.GetFeaturesList;

public class GetFeaturesListQueryHandler : IRequestHandler<GetFeaturesListQuery, List<FeaturesListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Domain.Entities.Feature> _featureRepository;

    public GetFeaturesListQueryHandler(IMapper mapper,IAsyncRepository<Mohashan.UserManager.Domain.Entities.Feature> featureRepository)
    {
        _mapper = mapper;
        _featureRepository = featureRepository;
    }
    public async Task<List<FeaturesListVm>> Handle(GetFeaturesListQuery request, CancellationToken cancellationToken)
    {
        var allFeatures = (await _featureRepository.GetAllPagedAsync(request.PageCount,request.PageNumber)).OrderBy(c=>c.Name);

        return _mapper.Map<List<FeaturesListVm>>(allFeatures);
    }
}