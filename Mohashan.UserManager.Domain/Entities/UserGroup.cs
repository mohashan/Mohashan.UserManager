using Mohashan.UserManager.Domain.Common;

namespace Mohashan.UserManager.Domain.Entities
{
    public class UserGroup : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public Guid GroupId { get; set; }
        public Group Group { get; set; } = default!;
    }
}