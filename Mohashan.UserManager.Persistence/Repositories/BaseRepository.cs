using Microsoft.EntityFrameworkCore;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Exceptions;
using Mohashan.UserManager.Domain.Common;

namespace Mohashan.UserManager.Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
{
    protected readonly UserManagerDbContext _dbContext;

    public BaseRepository(UserManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entry = _dbContext.Set<T>().FirstOrDefaultAsync(c => c.Id == id);
        if (entry == null)
        {
            throw new NotFoundException(nameof(T), id);
        }

        _dbContext.Entry(entry).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<IReadOnlyList<T>> GetAllPagedAsync(int count = 10, int pageNum = 1)
    {
        return await _dbContext.Set<T>().OrderBy(c => c.CreatedDateTime).Skip((pageNum - 1) * count).Take(count).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetListAsync()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>()
                               .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}