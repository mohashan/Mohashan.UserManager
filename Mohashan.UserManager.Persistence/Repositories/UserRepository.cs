using Microsoft.EntityFrameworkCore;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(UserManagerDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<ICollection<User>> GetGroupUsers(Guid groupId,int count, int pageNum = 1)
    {
        return await _dbContext.userGroups
            .Where(c=>c.GroupId == groupId)
            .Select(c=>c.User)
            .Skip((pageNum - 1) * count)
            .Take(count)
            .ToListAsync();
    }

    public async Task<ICollection<UserFeature>> GetUserFeatures(Guid userId, int count = 10, int pageNum = 1)
    {
        return await _dbContext.userFeatures
            .Where(c => c.UserId == userId)
            .Skip((pageNum - 1) * count)
            .Take(count)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<User>> GetUserListWithTypeAsync()
    {
        return await _dbContext.Users.Include(c=>c.UserType).ToListAsync();
    }

    public async Task<bool> UsernameIsUnique(string userName)
    {
        return !(await _dbContext.Users.AnyAsync(c=>c.Name.Equals(userName,StringComparison.OrdinalIgnoreCase)));
    }

    public override async Task<IReadOnlyList<User>> GetAllPagedAsync(int count = 10, int pageNum = 1)
    {
        return await _dbContext.Set<User>().OrderBy(c => c.Name).Skip((pageNum - 1) * count).Take(count).ToListAsync();

    }
}
