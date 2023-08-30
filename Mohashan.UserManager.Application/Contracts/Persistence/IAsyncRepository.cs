using Mohashan.UserManager.Domain.Common;

namespace Mohashan.UserManager.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IReadOnlyList<T>> GetAllPagedAsync(int count = 10, int pageNum = 1);

        Task<IReadOnlyList<T>> GetListAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(Guid id);
    }
}