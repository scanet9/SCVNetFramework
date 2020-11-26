using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CosmosDBRestApi.DataLayer.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CosmosDBRestApi.DataLayer.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext _context;
        private Dictionary<(Type type, string name), object> _repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public ICosmosRepository<T> GetRepository<T>() where T : BaseDocument
        {
            return (ICosmosRepository<T>)GetOrAddRepository(typeof(T), new CosmosRepository<T>(_context));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        internal object GetOrAddRepository(Type type, object repo)
        {
            _repositories ??= new Dictionary<(Type type, string Name), object>();

            if (_repositories.TryGetValue((type, repo.GetType().FullName), out var repository)) return repository;
            _repositories.Add((type, repo.GetType().FullName), repo);
            return repo;
        }
    }
}
