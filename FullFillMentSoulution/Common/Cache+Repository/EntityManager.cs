using Common.Cache;
using Common.Model;
using Common.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache_Repository
{
    public class EntityQueryManager<TEntity> where TEntity : Entity
    {
        private readonly IEntityQueryRepository<TEntity> _entityQueryRepository;
        private readonly EntityMemoryModule _entityMemoryModule;
        public EntityQueryManager(IEntityQueryRepository<TEntity> entityQueryRepository, EntityMemoryModule entityMemoryModule)
        {
            _entityQueryRepository = entityQueryRepository;
            _entityMemoryModule = entityMemoryModule;
        }
        public async Task<List<TEntity>> GetToList()
        {

        }
    }
}
