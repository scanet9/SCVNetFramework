using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CosmosDBRestApi.BusinessLogic.Services.Interfaces;
using CosmosDBRestApi.DataLayer.Infrastructure.Interfaces;
using CosmosDBRestApi.DataLayer.DocumentModels.User;

namespace CosmosDBRestApi.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> CreateUserProvaAsync(User user)
        {
            var entityEntry = await _uow.GetRepository<User>().CreateAsync(user);
            await _uow.SaveChangesAsync();
            return entityEntry;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var result = await _uow.GetRepository<User>().GetAllAsync();
            return result;
        }

        public async Task<IEnumerable<User>> GetActiveUsers()
        {
            var result = await _uow.GetRepository<User>().GetAsync(x => x.Active);
            return result;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var result = await _uow.GetRepository<User>().GetByIdAsync(id);
            return result != null ? result : new User();
        }

        public async Task<User> UpdateUserProvaAsync(User user)
        {
            var entityEntry = _uow.GetRepository<User>().Update(user);
            await _uow.SaveChangesAsync();
            return entityEntry;
        }

        public async Task<User> DeleteUserProvaAsync(Guid id)
        {
            var entityEntry = await _uow.GetRepository<User>().DeleteAsync(id);
            await _uow.SaveChangesAsync();
            return entityEntry;
        }
    }
}
