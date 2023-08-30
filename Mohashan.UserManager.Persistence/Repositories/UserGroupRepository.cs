using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Persistence.Repositories;

public class UserGroupRepository : BaseRepository<UserGroup>, IUserGroupRepository
{
    public UserGroupRepository(UserManagerDbContext dbContext) : base(dbContext)
    {
    }
}