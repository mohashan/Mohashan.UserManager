using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.UpdateFeature;

public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Domain.Entities.Feature> _featureRepository;

    public UpdateFeatureCommandHandler(IMapper mapper,IAsyncRepository<Domain.Entities.Feature> featureRepository)
    {
        _mapper = mapper;
        _featureRepository = featureRepository;
    }
    public async Task<Unit> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var featureToUpdate = await _featureRepository.GetByIdAsync(request.Id);
        _mapper.Map(request, featureToUpdate,typeof(UpdateFeatureCommand),typeof(Domain.Entities.Feature));
        await _featureRepository.UpdateAsync(featureToUpdate);
        return Unit.Value;
    }
}
