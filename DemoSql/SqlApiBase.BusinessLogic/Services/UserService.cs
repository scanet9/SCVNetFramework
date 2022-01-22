using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SCVNetFramework.DataLayer.Sql.Infrastructure.Interfaces;
using SqlApiBase.BusinessLogic.Services.Interfaces;
using SqlApiBase.DataLayer.DataTransferObjects;
using SqlApiBase.DataLayer.Entities;

namespace SqlApiBase.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UserService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<AuthenticationResponseDto> AuthenticateAsync(AuthenticationRequestDto credentials, string jwtSecret)
        {
            if (!(string.IsNullOrEmpty(credentials.Email) || string.IsNullOrEmpty(credentials.Password)))
            {

                var user = (await _uow.GetRepository<User>().GetAsync(x => x.Email == credentials.Email)).SingleOrDefault();

                if (user != null && BCrypt.Net.BCrypt.Verify(credentials.Password, user.PasswordHash))
                    return new AuthenticationResponseDto(user, GenerateJwtToken(user, jwtSecret));
            }
            return new AuthenticationResponseDto();
        }

        public async Task<User> RegisterAsync(RegisterUserRequestDto registerUserDto)
        {
            if (string.IsNullOrEmpty(registerUserDto.Email) || string.IsNullOrEmpty(registerUserDto.Password))
                throw new ArgumentException("Neither email nor password can be empty");

            if ((await _uow.GetRepository<User>().GetAsync(x => x.Email == registerUserDto.Email)).Any())
                throw new ArgumentException("This email is already registered");

            User user = _mapper.Map<User>(registerUserDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password);

            var result = await _uow.GetRepository<User>().CreateAsync(user);
            await _uow.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var result = await _uow.GetRepository<User>().GetAllAsync();
            return result;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var result = await _uow.GetRepository<User>().GetByIdAsync(id);
            return result != null ? result : new User();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return (await _uow.GetRepository<User>().GetAsync(x => x.Email == email)).SingleOrDefault();
        }

        public async Task<User> UpdateUserAsync(Guid id, UpdateUserRequestDto updateUserDto)
        {
            var user = await _uow.GetRepository<User>().GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("User does not exist");

            _mapper.Map(updateUserDto, user);

            if (!String.IsNullOrEmpty(updateUserDto.NewPassword))
            {
                if (BCrypt.Net.BCrypt.Verify(updateUserDto.OldPassword, user.PasswordHash))
                {
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateUserDto.NewPassword);
                }
                else throw new ArgumentException("Old password incorrect");
            }

            var entityEntry = _uow.GetRepository<User>().Update(user);
            await _uow.SaveChangesAsync();
            return entityEntry;
        }

        public async Task<User> DeleteUserAsync(Guid id)
        {
            var entityEntry = await _uow.GetRepository<User>().DeleteAsync(id);
            await _uow.SaveChangesAsync();
            return entityEntry;
        }

        private static string GenerateJwtToken(User user, string jwtSecret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
