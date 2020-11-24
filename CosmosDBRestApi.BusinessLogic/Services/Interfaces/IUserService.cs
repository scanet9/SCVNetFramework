using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CosmosDBRestApi.DataLayer.DocumentModels.User;

namespace CosmosDBRestApi.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserProvaAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetActiveUsers();
        Task<User> GetByIdAsync(Guid id);
        Task<User> UpdateUserProvaAsync(User user);
        Task<User> DeleteUserProvaAsync(Guid id);
    }
}
