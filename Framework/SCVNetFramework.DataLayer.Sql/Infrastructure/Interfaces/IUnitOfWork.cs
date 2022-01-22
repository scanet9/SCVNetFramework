using System;
using System.Threading.Tasks;

namespace SCVNetFramework.DataLayer.Sql.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISqlRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
