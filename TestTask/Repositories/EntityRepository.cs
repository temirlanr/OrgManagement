using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.Settings;

namespace TestTask.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private const string databaseName = "OrgManagement";
        private const string collectionName = "Organizations";
        private readonly IMongoCollection<Entity> _entityCollection;

        public EntityRepository(IMongoClient mongoClient)
        {
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            _entityCollection = mongoDatabase.GetCollection<Entity>(collectionName);
        }

        public async Task<IEnumerable<Entity>> GetEntitiesAsync()
        {
            return await _entityCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Entity> GetEntityAsync(string id)
        {
            return await _entityCollection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateEntityAsync(Entity entity)
        {
            await _entityCollection.InsertOneAsync(entity);
        }

        public async Task UpdateEntityAsync(string id, Entity updatedEntity)
        {
            await _entityCollection.ReplaceOneAsync(e => e.Id == id, updatedEntity);
        }

        public async Task RemoveAsync(string id)
        {
            await _entityCollection.DeleteOneAsync(e => e.Id == id);
        }
    }
}
