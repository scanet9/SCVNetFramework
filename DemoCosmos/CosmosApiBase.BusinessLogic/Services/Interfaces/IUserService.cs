﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CosmosApiBase.DataLayer.DataTransferObjects;
using CosmosApiBase.DataLayer.DocumentModels.User;

namespace CosmosApiBase.BusinessLogic.Services.Interfaces
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
