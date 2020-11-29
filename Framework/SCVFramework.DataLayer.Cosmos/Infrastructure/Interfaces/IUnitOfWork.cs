using System;
using System.Threading.Tasks;

namespace SCVFramework.DataLayer.Cosmos.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICosmosRepository<T> GetRepository<T>() where T : BaseDocument;
        Task<int> SaveChangesAsync();
    }
}
