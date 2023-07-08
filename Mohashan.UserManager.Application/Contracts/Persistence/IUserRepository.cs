using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserFeatures(Guid userId);
        Task<ICollection<User>> GetGroupUsers(Guid groupId);
        Task<bool> UsernameIsUnique(string userName);
    }
}
