using System;
using System.Threading.Tasks;

namespace CosmosDBRestApi.DataLayer.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICosmosRepository<T> GetRepository<T>() where T : BaseDocument;
        Task<int> SaveChangesAsync();
    }
}
