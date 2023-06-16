using System.Diagnostics.SymbolStore;
using Mohashan.UserManager.Domain.Common;

namespace Mohashan.UserManager.Domain.Entities
{
    public class UserType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

    }

}
