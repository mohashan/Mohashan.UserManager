using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<ICollection<UserFeature>> GetUserFeatures(Guid userId, int count = 10, int pageNum = 1);

        Task<ICollection<User>> GetGroupUsers(Guid groupId, int count = 10, int pageNum = 1);

        Task<bool> UsernameIsUnique(string userName);

        Task<IReadOnlyList<User>> GetUserListWithTypeAsync();
    }
}