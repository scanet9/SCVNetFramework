using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CosmosDBRestApi.DataLayer.Infrastructure.Interfaces
{
    public interface ICosmosRepository<T> where T: BaseEntity
    {
        Task<T> CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Guid id);
        T Update(T entity);
        Task<T> DeleteAsync(Guid id);
    }
}
