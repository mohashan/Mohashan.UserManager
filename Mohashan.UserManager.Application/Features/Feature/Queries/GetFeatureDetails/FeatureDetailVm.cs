namespace Mohashan.UserManager.Application.Features.Feature.Queries.GetFeatureDetails;

public class FeatureDetailVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public string? Description { get; set; }
}
