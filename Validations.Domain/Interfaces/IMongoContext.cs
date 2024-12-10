using MongoDB.Driver;

namespace Validations.Repository
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
        IMongoDatabase GetDatabase();
    }
}