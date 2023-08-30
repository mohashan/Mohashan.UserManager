using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Persistence.Repositories;

public class FeatureRepository : BaseRepository<Feature>, IFeatureRepository
{
    public FeatureRepository(UserManagerDbContext dbContext) : base(dbContext)
    {
    }
}