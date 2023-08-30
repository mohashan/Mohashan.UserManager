using Mohashan.UserManager.Domain.Common;

namespace Mohashan.UserManager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid UserTypeId { get; set; }
        public virtual UserType UserType { get; set; } = default!;
        public virtual ICollection<UserFeature>? UserFeatures { get; set; }

        public virtual ICollection<UserGroup>? UserGroup { get; set; }
    }
}