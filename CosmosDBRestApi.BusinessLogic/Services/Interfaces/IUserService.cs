using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CosmosDBRestApi.DataLayer.DataTransferObjects;
using CosmosDBRestApi.DataLayer.DocumentModels.User;

namespace CosmosDBRestApi.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponseDto> AuthenticateAsync(AuthenticationRequestDto credentials, string jwtSecret);
        Task<User> RegisterAsync(RegisterUserDto registerDto);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetActiveUsers();
        Task<User> GetByIdAsync(Guid id);
        Task<User> UpdateUserAsync(Guid id, UpdateUserDto user);
        Task<User> DeleteUserAsync(Guid id);
    }
}
