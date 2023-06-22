using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.CreateFeature;

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Domain.Entities.Feature> _featureRepository;

    public CreateFeatureCommandHandler(IMapper mapper,IAsyncRepository<Domain.Entities.Feature> featureRepository)
    {
        _mapper = mapper;
        _featureRepository = featureRepository;
    }
    public async Task<Guid> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = await _featureRepository.AddAsync(_mapper.Map<Domain.Entities.Feature>(request));
        return feature.Id;
    }
}
