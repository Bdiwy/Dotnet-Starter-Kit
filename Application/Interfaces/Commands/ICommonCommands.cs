using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface ICommonCommands<T> where T : class
    {
        Task SaveMeAsync(T entity);
        Task SaveAllAsync(IEnumerable<T> entity);
        Task UpdateAsync(T entity, Guid id);
        Task DeleteAllAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
    }
}