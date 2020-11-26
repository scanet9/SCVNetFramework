using System;
using System.Text.Json.Serialization;
using CosmosDBRestApi.DataLayer.Infrastructure;

namespace CosmosDBRestApi.DataLayer.DocumentModels.User
{
    public class User : BaseDocument
    {
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public bool Active { get; set; }
    }
}
