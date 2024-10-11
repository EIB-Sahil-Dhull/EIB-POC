using MongoDB.Driver;

namespace GDPR_POC.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task DeleteAsync(string id);
    }
}
