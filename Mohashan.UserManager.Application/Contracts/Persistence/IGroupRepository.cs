using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Contracts.Persistence
{
    public interface IGroupRepository : IAsyncRepository<Group>
    {
    }
}