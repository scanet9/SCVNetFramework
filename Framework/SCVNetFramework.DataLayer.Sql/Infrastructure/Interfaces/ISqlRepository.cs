using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SCVNetFramework.DataLayer.Sql.Infrastructure.Interfaces
{
    public interface ISqlRepository<T> where T : class
    {
        Task<T> CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> orderBy = null, int skip = 0, int take = 0);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderBy = null, int skip = 0, int take = 0);
        Task<T> GetByIdAsync(Guid id);
        T Update(T entity);
        Task<T> DeleteAsync(Guid id);
        Task<List<Q>> RawSqlQueryAsync<Q>(string query, Func<DbDataReader, Q> map);
    }
}
