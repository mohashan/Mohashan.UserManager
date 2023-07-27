using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Persistence.Repositories;

public class UserFeatureRepository : BaseRepository<UserFeature>, IUserFeatureRepository
{
    public UserFeatureRepository(UserManagerDbContext dbContext) : base(dbContext)
    {

    }


}
