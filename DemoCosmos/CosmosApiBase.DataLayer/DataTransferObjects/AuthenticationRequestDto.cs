using System;
namespace CosmosApiBase.DataLayer.DataTransferObjects
{
    public class AuthenticationRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
