using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Feature.Queries.GetFeatureDetails;

public class GetFeatureDetailQueryHandler : IRequestHandler<GetFeatureDetailQuery, FeatureDetailVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Domain.Entities.Feature> _featureRepository;

    public GetFeatureDetailQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Feature> featureRepository)
    {
        _mapper = mapper;
        _featureRepository = featureRepository;
    }

    public async Task<FeatureDetailVm> Handle(GetFeatureDetailQuery request, CancellationToken cancellationToken)
    {
        var featureDetail = await _featureRepository.GetByIdAsync(request.Id);

        return _mapper.Map<FeatureDetailVm>(featureDetail);
    }
}