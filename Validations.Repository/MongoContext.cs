using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Validations.Repository
{
    public class MongoContext : IMongoContext
    {
        private readonly MongoClient _mongoClient;
        private const string DATABASE = "db";
        public MongoContext(IConfiguration configuration)
        {
            var settings = MongoClientSettings.FromConnectionString(configuration["MONGODB_CONNECTIONSTRING"]);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            _mongoClient = new MongoClient(settings);
        }
        public IMongoDatabase GetDatabase()
        {
            return _mongoClient.GetDatabase(DATABASE);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return GetDatabase().GetCollection<T>(name);
        }
    }
}
