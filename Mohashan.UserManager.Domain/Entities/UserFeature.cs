using Mohashan.UserManager.Domain.Common;

namespace Mohashan.UserManager.Domain.Entities
{
    public class UserFeature : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; } = default!;

        public string Value { get; set; } = string.Empty;
    }
}