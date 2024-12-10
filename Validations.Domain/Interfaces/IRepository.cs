using MongoDB.Driver;

namespace Validations.Repository.MongoDB
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(string id);
        Task<TEntity> GetAsync(string id);
        Task<IEnumerable<TEntity>> ListAsync();
        Task UpdateAsync(TEntity entity);
    }
}