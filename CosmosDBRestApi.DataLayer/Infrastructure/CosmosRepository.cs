using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using CosmosDBRestApi.DataLayer.Infrastructure.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace CosmosDBRestApi.DataLayer.Infrastructure
{
    public class CosmosRepository<T> : ICosmosRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public CosmosRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            var response = await _context.Set<T>().AddAsync(entity);
            return response.Entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public T Update(T entity)
        {
            var response = _context.Set<T>().Update(entity);
            return response.Entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            var response = _context.Set<T>().Remove(entity);
            return response.Entity;
        }
    }
}
