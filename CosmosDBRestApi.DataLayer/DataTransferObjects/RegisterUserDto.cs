using System;
namespace CosmosDBRestApi.DataLayer.DataTransferObjects
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public bool Active { get; set; }
    }
}
