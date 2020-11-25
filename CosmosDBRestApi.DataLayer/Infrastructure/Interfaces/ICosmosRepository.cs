using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CosmosDBRestApi.DataLayer.Infrastructure.Interfaces
{
    public interface ICosmosRepository<T> where T: BaseEntity
    {
        Task<T> CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync(string partitionKey = "");
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression, string partitionKey = "");
        Task<T> GetByIdAsync(Guid id, string partitionKey = "");
        T Update(T entity);
        Task<T> DeleteAsync(Guid id);
    }
}
