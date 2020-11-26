using System;
using CosmosDBRestApi.DataLayer.Infrastructure;

namespace CosmosDBRestApi.DataLayer.DocumentModels.User
{
    public class User : BaseDocument
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public bool Active { get; set; }
    }
}
