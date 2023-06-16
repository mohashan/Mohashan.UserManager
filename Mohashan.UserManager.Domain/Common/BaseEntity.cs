using System.Text.Json.Serialization;

namespace Mohashan.UserManager.Domain.Common
{
    public abstract class BaseEntity:AuditableEntity
    {
        public Guid Id { get; set; }

    }

}
