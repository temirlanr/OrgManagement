using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.Repositories;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IEntityRepository _entityRepository;
        private static readonly HttpClient client = new HttpClient();

        public EntityController(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entity>>> GetEntities()
        {
            var entities = await _entityRepository.GetEntitiesAsync();
            return Ok(entities);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Entity>> GetEntity(string id)
        {
            var entity = await _entityRepository.GetEntityAsync(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> PostEntity(Entity entity)
        {
            await _entityRepository.CreateEntityAsync(entity);

            return CreatedAtAction(nameof(GetEntity), new { id = entity.Id }, entity);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> PutEntity(string id, Entity entity)
        {
            var existingEntity = await _entityRepository.GetEntityAsync(id);

            if(existingEntity == null)
            {
                return NotFound();
            }

            entity.Id = existingEntity.Id;

            await _entityRepository.UpdateEntityAsync(id, entity);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteEntity(string id)
        {
            var existingEntity = await _entityRepository.GetEntityAsync(id);

            if (existingEntity == null)
            {
                return NotFound();
            }

            await _entityRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}
