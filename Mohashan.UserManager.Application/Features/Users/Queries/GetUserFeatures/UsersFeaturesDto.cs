using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUserFeatures;

public class UserFeaturesDto
{
    public string FeatureName { get; set; } = string.Empty;
    public string FeatureDataType { get; set; } = string.Empty;
    public string? FeatureDescription { get; set; }
    public string Value { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
