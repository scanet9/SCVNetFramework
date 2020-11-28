using System;
using System.Threading.Tasks;

namespace SCVCosmosFramework.DataLayer.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICosmosRepository<T> GetRepository<T>() where T : BaseDocument;
        Task<int> SaveChangesAsync();
    }
}
