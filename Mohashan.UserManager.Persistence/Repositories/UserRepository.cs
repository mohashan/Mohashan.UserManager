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

    public async Task<ICollection<Feature>> GetUserFeatures(Guid userId, int count = 10, int pageNum = 1)
    {
        return await _dbContext.userFeatures
            .Where(c => c.UserId == userId)
            .Skip((pageNum - 1) * count)
            .Take(count)
            .Select(c => c.Feature)
            .ToListAsync();
    }

    public async Task<bool> UsernameIsUnique(string userName)
    {
        return !(await _dbContext.Users.AnyAsync(c=>c.Name.Equals(userName,StringComparison.OrdinalIgnoreCase)));
    }
}
