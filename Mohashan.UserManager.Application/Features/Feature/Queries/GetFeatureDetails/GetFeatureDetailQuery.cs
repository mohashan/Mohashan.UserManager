using MediatR;

namespace Mohashan.UserManager.Application.Features.Feature.Queries.GetFeatureDetails;

public class GetFeatureDetailQuery : IRequest<FeatureDetailVm>
{
    public Guid Id { get; set; }
}