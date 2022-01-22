using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SCVNetFramework.DataLayer.Sql.Infrastructure.Interfaces;

namespace SCVNetFramework.DataLayer.Sql.Infrastructure
{
    public class SqlRepository<T> : ISqlRepository<T> where T : BaseEntity
    {
        private DbContext _context { get; set; }

        public SqlRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            var response = await _context.Set<T>().AddAsync(entity);
            return response.Entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> orderBy = null, int skip = 0, int take = 0)
        {
            var filter = _context.Set<T>().AsQueryable();

            if (orderBy != null)
                filter = filter.OrderBy(orderBy);

            if (take > 0)
                filter = filter.Skip(skip).Take(take);

            return await filter.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderBy = null, int skip = 0, int take = 0)
        {
            var filter = _context.Set<T>().Where(expression);

            if (orderBy != null)
                filter = filter.OrderBy(orderBy);

            if (take > 0)
                filter = filter.Skip(skip).Take(take);

            return await filter.ToListAsync();
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

        public async Task<List<Q>> RawSqlQueryAsync<Q>(string query, Func<DbDataReader, Q> map)
        {
            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            _context.Database.OpenConnection();

            using var result = await command.ExecuteReaderAsync();
            var entities = new List<Q>();

            while (await result.ReadAsync())
                entities.Add(map(result));

            return entities;
        }
    }
}
