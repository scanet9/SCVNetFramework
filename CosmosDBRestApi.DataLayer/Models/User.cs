using System;
using CosmosDBRestApi.DataLayer.Infrastructure;

namespace CosmosDBRestApi.DataLayer.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
    }
}
