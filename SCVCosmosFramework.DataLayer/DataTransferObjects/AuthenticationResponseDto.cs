using System;
using SCVCosmosFramework.DataLayer.DocumentModels.User;

namespace SCVCosmosFramework.DataLayer.DataTransferObjects
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
