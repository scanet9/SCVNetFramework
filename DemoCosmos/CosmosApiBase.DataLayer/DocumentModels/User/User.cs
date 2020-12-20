using System;
using System.Text.Json.Serialization;
using SCVFramework.DataLayer.Cosmos.Infrastructure;

namespace CosmosApiBase.DataLayer.DocumentModels.User
{
    public class User : BaseDocument
    {
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
    }
}
