using MediatR;

namespace Mohashan.UserManager.Application.Features.Feature.Queries.GetFeaturesList;

public class GetFeaturesListQuery : IRequest<List<FeaturesListVm>>
{
    public int PageCount { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
}
