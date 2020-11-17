using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosDBRestApi.DataLayer.Infrastructure.Interfaces
{
    public interface ICosmosDBRepository<T>
    {
        Task AddItemAsync(T item);
        Task UpdateItemAsync(string id, T item);
        Task DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        //Task<IEnumerable<T>> GetItemsAsync(string query);
    }
}
