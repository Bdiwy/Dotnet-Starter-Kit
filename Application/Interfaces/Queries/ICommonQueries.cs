using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface ICommonQueries<T> where T : class
    {
        public Task<T?> GetEntityByIdAsync(Guid id);
        public Task<List<T>> GetAllEntitiesAsync();
        public Task<List<T>> GetEntitiesByTenantIdAsync(Guid tenantId);

        public Task<List<T>> GetEntitiesByTenantIdWithConditionAsync(Guid tenantId, Func<T, bool> condition);
    }
}