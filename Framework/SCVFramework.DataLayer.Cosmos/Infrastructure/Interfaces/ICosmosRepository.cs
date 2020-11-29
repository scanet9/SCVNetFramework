using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SCVFramework.DataLayer.Cosmos.Infrastructure.Interfaces
{
    public interface ICosmosRepository<T> where T: BaseDocument
    {
        Task<T> CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync(string partitionKey = "");
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression, string partitionKey = "");
        Task<T> GetByIdAsync(Guid id, string partitionKey = "");
        T Update(T entity);
        Task<T> DeleteAsync(Guid id);
    }
}
