using Mohashan.UserManager.Domain.Common;

namespace Mohashan.UserManager.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<UserGroup>? UserGroups { get; set; }
    }
}