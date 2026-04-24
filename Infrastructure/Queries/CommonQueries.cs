using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces.Queries;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class CommonQueries<T>(ApplicationDbContext context) : ICommonQueries<T>
    where T : class , ITenantEntity
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();
        public async Task<T?> FetchFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T?> GetEntityByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllEntitiesAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetEntitiesDataWithConditionAsync(Func<T, bool> condition)
        {
            return await Task.FromResult(_dbSet
                            .AsEnumerable()
                            .Where(condition)
                            .ToList());
        }
    }
}