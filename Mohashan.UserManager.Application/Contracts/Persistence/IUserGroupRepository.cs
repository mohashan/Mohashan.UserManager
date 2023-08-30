using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Contracts.Persistence
{
    public interface IUserGroupRepository : IAsyncRepository<UserGroup>
    {
    }
}