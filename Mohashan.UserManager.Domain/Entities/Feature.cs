using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Mohashan.UserManager.Domain.Common;

namespace Mohashan.UserManager.Domain.Entities
{
    public class Feature : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;

        public string? Description { get; set; }
        public virtual ICollection<UserFeature>? UserFeatures { get; set; }
    }

}
