using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Repositories
{
    public interface IEntityRepository
    {
        Task<IEnumerable<Entity>> GetEntitiesAsync();
        Task<Entity> GetEntityAsync(string id);
        Task CreateEntityAsync(Entity entity);
        Task UpdateEntityAsync(string id, Entity updatedEntity);
        Task RemoveAsync(string id);
    }
}
