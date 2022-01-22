using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SqlApiBase.DataLayer.DataTransferObjects;
using SqlApiBase.DataLayer.Entities;

namespace SqlApiBase.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResponseDto> AuthenticateAsync(AuthenticationRequestDto credentials, string jwtSecret);
        Task<User> RegisterAsync(RegisterUserRequestDto registerDto);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<User> UpdateUserAsync(Guid id, UpdateUserRequestDto user);
        Task<User> DeleteUserAsync(Guid id);
    }
}
