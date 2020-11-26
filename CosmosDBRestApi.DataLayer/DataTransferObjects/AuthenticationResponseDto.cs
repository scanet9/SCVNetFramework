using System;
using CosmosDBRestApi.DataLayer.DocumentModels.User;

namespace CosmosDBRestApi.DataLayer.DataTransferObjects
{
    public class AuthenticationResponseDto
    {
        public User User { get; set; }
        public string JwtToken { get; set; }

        public AuthenticationResponseDto()
        {
        }

        public AuthenticationResponseDto(User user, string token)
        {
            User = user;
            JwtToken = token;
        }
    }
}
