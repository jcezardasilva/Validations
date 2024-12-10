using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validations.Domain.Entities.Rules;

namespace Validations.Repository.MongoDB
{
    public class RuleRepository(IMongoContext mongoContext) : IRepository<RuleEntity>
    {
        private readonly IMongoDatabase _mongo = mongoContext.GetDatabase();
        public async Task AddAsync(RuleEntity entity)
        {
            try
            {
                await _mongo.GetCollection<RuleEntity>("rules").InsertOneAsync(entity);
            }
            catch (MongoWriteException ex)
            {
                throw new Exception("Failed to add an rule", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error on adding rule", ex);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _mongo.GetCollection<RuleEntity>("rules").DeleteOneAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error on deleting rule", ex);
            }
        }

        public async Task<RuleEntity> GetAsync(string id)
        {
            try
            {
                return (await _mongo.GetCollection<RuleEntity>("rules").FindAsync(Builders<RuleEntity>.Filter.Eq("Id", id))).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error on getting rule", ex);
            }
        }

        public async Task UpdateAsync(RuleEntity entity)
        {
            try
            {
                var filter = Builders<RuleEntity>.Filter.Eq("Id", entity.Id);
                var update = Builders<RuleEntity>.Update.Set("Name", entity.Name);

                await _mongo.GetCollection<RuleEntity>("rules").FindOneAndUpdateAsync<RuleEntity>(filter, update);
            }
            catch (MongoWriteException ex)
            {
                throw new Exception("Failed to update an rule", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error on updating rules", ex);
            }
        }
        public async Task<IEnumerable<RuleEntity>> ListAsync()
        {
            try
            {
                var result = await _mongo.GetCollection<RuleEntity>("rules").FindAsync(_ => true);
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error on listing rules", ex);
            }
        }
    }
}
