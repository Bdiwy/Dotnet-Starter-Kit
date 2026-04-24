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
    public class CommonCommands<T>(ApplicationDbContext context) : ICommonCommands<T>
        where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task SaveMeAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await context.SaveChangesAsync();            
        }

        public async Task SaveAllAsync(IEnumerable<T> entities)
        {
            await  _dbSet.AddRangeAsync(entities);
            await context.SaveChangesAsync();            
        }
    }
}