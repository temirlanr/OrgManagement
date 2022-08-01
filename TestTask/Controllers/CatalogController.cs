using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;
using TestTask.Repositories;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IEntityRepository _entityRepository;
        private readonly List<Catalog> Oked = JsonConvert.DeserializeObject<List<Catalog>>(System.IO.File.ReadAllText("JsonOked.json"));
        private readonly List<Catalog> KRP = JsonConvert.DeserializeObject<List<Catalog>>(System.IO.File.ReadAllText("JsonKRP.json"));

        public CatalogController(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        
    }
}
